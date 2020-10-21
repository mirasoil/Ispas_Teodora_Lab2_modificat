using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Threading;

namespace Ispas_Teodora_Lab2_modificat
{
    class DoughnutMachine : Component
    {
        private DoughnutType mFlavor;
        public DoughnutType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }
        //colectia - pas 5 lab 3
        private System.Collections.ArrayList mDoughnuts = new System.Collections.ArrayList();
        //indexer - pas 5 lab 3    
        public Doughnut this[int Index]
            {
                get
                {
                    return (Doughnut)mDoughnuts[Index];
                }
                set
                {
                    mDoughnuts[Index] = value;
                }
            }
        //delegate public - punctul 6 lab 3
        public delegate void DoughnutCompleteDelegate();
        public event DoughnutCompleteDelegate DoughnutComplete;

        //obiect de tip dispatcherTimer - monitorizeaza timpul de coacere - pas 7 lab 3
        DispatcherTimer doughnutTimer;

        //initializare doughnutTimer
        private void InitializeComponent()
        {
            this.doughnutTimer = new DispatcherTimer();

            this.doughnutTimer.Tick += new System.EventHandler(this.doughnutTimer_Tick);
        }

        //constructor care apeleaza metoda InitializeComponent - pas 9 lab 3
        public DoughnutMachine()
        {
            InitializeComponent();
        }
        //handler de eveniment - pas 10 lab 3
        private void doughnutTimer_Tick(object sender, EventArgs e)
        {
            Doughnut aDoughnut = new Doughnut(this.Flavor);
            mDoughnuts.Add(aDoughnut);
            DoughnutComplete();
        }

        //proprietati ce servesc pt a seta prop interne ale timerului - pas 11 lab 3
        public bool Enabled
        {
            set
            {
                doughnutTimer.IsEnabled = value;
            }
        }
        public int Interval
        {
            set
            {
                doughnutTimer.Interval = new TimeSpan(0, 0, value);
            }
        }

        //metoda care seteaza masina sa creeze tipul corect de gogoasa
        public void MakeDoughnuts(DoughnutType dFlavor)
        {
            Flavor = dFlavor;
            switch (Flavor)
            {
                case DoughnutType.Glazed:Interval = 3; break;
                case DoughnutType.Sugar: Interval = 2; break;
                case DoughnutType.Lemon: Interval = 5; break;
                case DoughnutType.Chocolate: Interval = 7; break;
                case DoughnutType.Vanilla: Interval = 4; break;
            }
            doughnutTimer.Start();
        }
    }



    public enum DoughnutType
    {
        Glazed,
        Sugar,
        Lemon,
        Chocolate,
        Vanilla
    }
    class Doughnut
    {
        private DoughnutType mFlavor;

        public DoughnutType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }
        private float mPrice = .50F;
        public float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
        private readonly DateTime mTimeOfCreation;
        public DateTime TimeOfCreation
        {
            get
            {
                return mTimeOfCreation;
            }
        }
        public Doughnut(DoughnutType aFlavor) //constructor!!
        {
            mTimeOfCreation = DateTime.Now;
            mFlavor = aFlavor;
        }

    }

}
