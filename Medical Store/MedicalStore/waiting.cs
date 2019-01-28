using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalStore
{
    public partial class waiting : MetroFramework.Forms.MetroForm
    {
        public Action Worker { get; set; }
        public waiting(Action action)
        {
            InitializeComponent();
            if (action == null)
                throw new ArgumentNullException();
            Worker = action;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(y => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
