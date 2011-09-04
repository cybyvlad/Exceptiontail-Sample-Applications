using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using ExceptionTail;

using log4net;

using Timer = System.Threading.Timer;

namespace BuggyApp
{
    public partial class ExceptionGeneratorForm : Form
    {
        private Timer _timer;

        public ExceptionGeneratorForm()
        {
            InitializeComponent();
        }

        private int _maxPerSecond;

        private Stopwatch _stopWatch;

        private const string SENT = "Sent '{0}' exceptions.";

        private void RandomException()
        {
            Thrower.Throw();
        }

        private void btnSendGazzillion_Click(object sender, EventArgs e)
        {
            if (bwSendGazillion.IsBusy)
            {
                MessageBox.Show("BUSY!");
                return;
            }

            _maxPerSecond = (int) nupMaxPerSecond.Value;

            _stopWatch = Stopwatch.StartNew();
            bwSendGazillion.RunWorkerAsync();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            bwSendGazillion.CancelAsync();
        }

        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private void bwSendGazillion_DoWork(object sender, DoWorkEventArgs e)
        {
            _logger.Info("Sending gazillions");

            var backgroundWorker = (BackgroundWorker) sender;

            var sent = 0;

            for (var i = 1; i <= 20*1000*1000; i++)
            {
                if (backgroundWorker.CancellationPending)
                {
                    _logger.Info("BW canceled");
                    return;
                }
                var lastSecond = _stopWatch.Elapsed.Seconds;
                for (var j = 0; j < _maxPerSecond; j++)
                {
                    if (_stopWatch.Elapsed.Seconds > lastSecond)
                    {
                        break;
                    }
                    Exception exception = null;
                    try
                    {
                        RandomException();
                    }
                    catch (Exception oops)
                    {
                        exception = oops;
                    }
                    try
                    {
                        _logger.Info("Calling Publish method");

                        ET.Publish(exception);

                        _logger.Info("Publish");
                        backgroundWorker.ReportProgress(sent++);
                    }
                    catch (Exception oops)
                    {
                        Invoke(new MethodInvoker(() => MessageBox.Show(oops.StackTrace)));
                    }
                }
                while (lastSecond == _stopWatch.Elapsed.Seconds)
                {
                    Thread.Sleep(2);
                }
            }
        }

        private void bwSendGazillion_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblg.Text = string.Format(SENT, e.ProgressPercentage) + " throughput = " +
                        e.ProgressPercentage/
                        (_stopWatch.Elapsed.TotalSeconds == 0 ? 1 : _stopWatch.Elapsed.TotalSeconds);
        }

        private void RefreshStatus()
        {
            var stats = ET.GetStats();

            var numberOfExceptionsInQueue = stats.NumberOfExceptionsInQueue;
            var numberOfExceptionsSent = stats.NumberOfExceptionsSent;
            var numberOfExceptionsInSendQueue = stats.NumberOfExceptionsInSendQueue;

            if (label1.InvokeRequired)
            {
                label1.Invoke(new Action(() =>
                                         label1.Text =
                                         string.Format(
                                             "Exceptions in local queue: {0}. Exceptions sent {1}. Exceptions in send queue {2}",
                                             numberOfExceptionsInQueue,
                                             numberOfExceptionsSent,
                                             numberOfExceptionsInSendQueue)
                                  ));
            }
            else
            {
                label1.Text = string.Format("Exceptions in queue: {0}. Exceptions sent {1}", numberOfExceptionsInQueue,
                                            numberOfExceptionsSent);
            }
        }

        private void bwSendGazillion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void nupMaxPerSecond_ValueChanged(object sender, EventArgs e)
        {
            var value = (int) nupMaxPerSecond.Value;
            Interlocked.Exchange(ref _maxPerSecond, value);
        }

        private void ExceptionGeneratorForm_Load(object sender, EventArgs e)
        {
            btnShowLocalExceptions.Enabled = ETSettings.SaveExceptionsLocally;

            _timer = new Timer(x => RefreshStatus());
            _timer.Change(0, 200);
        }

        private void btnShowLocalExceptions_Click(object sender, EventArgs e)
        {
            using (var localExceptionsForm = new LocalExceptionsForm())
            {
                localExceptionsForm.ShowDialog();
            }
        }
    }
}