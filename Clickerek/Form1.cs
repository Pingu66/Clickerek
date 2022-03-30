namespace Clickerek
{
    public partial class Form1 : Form
    {
        private int cash;
        public int Cash
        {
            set
            {
                cash = value;
                label1.Text = "Cash: $" + value.ToString();
            }
            get
            {
                return cash;
            }
            
           
        }
        
        int buttonLevel;
        int A1Ammount;
        int A1Interval;
        int A2Interval;
        int A3Interval;
        int upgradeButton;
        
        public Form1()
        {
            InitializeComponent();
            Cash = 0;
            buttonLevel = 1;
            A1Ammount = 10;
            A1Interval = 0;
            A2Interval = 0;
            A3Interval = 0;
            upgradeButton = 1;
            
           
            A1AmmountTextBox.Text = A1Ammount.ToString();
            A1IntervalTextBox.Text = A1Interval.ToString();
            A2IntervalTextBox.Text = A2Interval.ToString();
            A3IntervalTextBox.Text = A3Interval.ToString();
            
        }
        //nabijanie kaski
        private void button1_Click(object sender, EventArgs e)
        {
            Cash += (int)Math.Pow(10, buttonLevel-1);
        }
        //
        //zwiaksza ilosc kaski na klikniecie
        private void upgradebutton_Click(object sender, EventArgs e)
        {
            int upgradeCost = (int)Math.Pow(10, buttonLevel);
            if(Cash >= upgradeCost)
            {
                buttonLevel++;
                buttonLevelTextBox.Text = buttonLevel.ToString();
                Cash -= upgradeCost;
                string nextUpgradeCost = "($" + Math.Pow(10,buttonLevel).ToString() + ")";
                upgradebutton.Text = "Upgrade\n" + nextUpgradeCost;
            }
        }
        //
        // useless
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //
        //przycisk zwiekszajacy zarabianie kaski paswyne 
        private void A1UpgradeInterval_Click(object sender, EventArgs e)
        {
            int upgradeCost = A1Interval * 100;
            if(Cash >= upgradeCost) {
                A1Interval++;
                A1IntervalTextBox.Text = A1Interval.ToString();
                A1Timer.Interval = (60 / A1Interval) * 100;
                if (!A1Timer.Enabled)
                    A1Timer.Enabled = true;
                Cash -= upgradeCost;
            }
        }
        //timer do kaski
        private void timer1_Tick(object sender, EventArgs e)
        {
            Cash += A1Ammount;
        }
        //
        //guzik ziekszajacy ilosc kaski zarabiajacej pasywnie
        private void A1UpgradeAmmount_Click(object sender, EventArgs e)
        {
            int upgradeCost2 = (int)Math.Pow(10, upgradeButton);
            if (Cash >= upgradeCost2)
            {
                upgradeButton++;
                A1AmmountTextBox.Text = upgradeButton.ToString();
                Cash -= upgradeCost2;
                string nextUpgradeCost = "($" + Math.Pow(10, upgradeButton).ToString() + ")";
                upgradebutton.Text = "Upgrade\n" + nextUpgradeCost;
                A1Ammount += 10;
                A1AmmountTextBox.Text = A1Ammount.ToString();
            }
           
        }
        //
        //przycisk ktory zarabia kaske szybciej i jest drozszy
        private void A2UpgradeInterval_Click(object sender, EventArgs e)
        {
            int upgradeCost = A2Interval * 1000;
            if (Cash >= upgradeCost)
            {
                A2Interval++;
                A2IntervalTextBox.Text = A2Interval.ToString();
                A2Timer.Interval = (60 / A2Interval) * 50;
                if (!A2Timer.Enabled)
                    A2Timer.Enabled = true;
                Cash -= upgradeCost;
                
            }
        }
        //
        //zegarek do drugiej kaski pasywnej 
        private void A2Timer_Tick(object sender, EventArgs e)
        {
            Cash += A1Ammount;
        }
        //
        //przycisk zarabiajacy kaske najszybciej + jest najdrozszy
        private void A3UpgradeInterval_Click(object sender, EventArgs e)
        {
            int upgradeCost = A3Interval * 10000;
            if (Cash >= upgradeCost)
            {
                A3Interval++;
                A3IntervalTextBox.Text = A3Interval.ToString();
                A3Timer.Interval = (60 / A3Interval) * 10;
                if (!A3Timer.Enabled)
                    A3Timer.Enabled = true;
                Cash -= upgradeCost;

            }
        }
        //
        //zegarek do trzeciej kaski pasywnej 
        private void A3Timer_Tick(object sender, EventArgs e)
        {
            Cash += A1Ammount;
        }
    }   //
    
}