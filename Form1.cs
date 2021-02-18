using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HaloFitnessApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        // Global variable declaration and intializing it to 0.
        DateTime JoiningDate = DateTime.Now;
        const int MEMBERRECORDLENGHT = 7;
        int RandomNumber;
        int NumberOfAttempts = 0, NumberOfAttemptsLeft = 3, MaximumAttempts = 3, ConfirmedTerm=0;
        decimal PricePerMonth=0m, PriceForSelectedFullterm=0m, PriceForNextFullTerm=0m, PricePerMonthNextTerm=0m;

        // Constant values declaration.
        const decimal BASEPRICE = 59, NEXTSTARTTERM3 = 3m, NEXTSTARTTERM7 = 7m, NEXTSTARTTERM13 = 13m, NEXTSTARTTERM19 = 19m, NEXTSTARTTERM25 = 25m, NEXTSTARTTERM60 = 60m;
        const decimal DISCOUNT0TO2 = 0.0m, DISCOUNT3TO6 = 0.1m, DISCOUNT7TO12 = 0.2m, DISCOUNT13TO18 = 0.25m, DISCOUNT19TO24 = 0.3333m, DISCOUNT25TO60 = 0.4m, DISCOUNTABOVE60 = 0.6666m;
        
       

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

      

        private void CommonSearchButton_Click(object sender, EventArgs e)
        {
            string MemberIdEntered = MembershipIdTextBox.Text;
            string MembershipIdPresent;
            string DOJ = DateOfJoiningTextBox.Text;
            try
            {
                if (MemberIdEntered != "" && DOJ == "")
                {
                    DateOfJoiningTextBox.Enabled = false;
                    int i;
                    SearchResultListBox.Items.Clear();
                    StreamReader InputFile;
                    InputFile = File.OpenText("HaloFitnessAppRecord.txt");
                    while (!InputFile.EndOfStream)
                    {
                        MembershipIdPresent = InputFile.ReadLine();
                        if (MembershipIdPresent == MemberIdEntered)
                        {
                            MessageBox.Show("success", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            SearchResultListBox.Items.Add(MembershipIdPresent);
                            for (i = 0; i < MEMBERRECORDLENGHT - 1; i++)
                            {

                                SearchResultListBox.Items.Add(InputFile.ReadLine());
                            }
                        }
                    }
                    if (SearchResultListBox.Items.Count == 0)
                    {

                        MessageBox.Show("MembershipId is not present", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


                else if (DOJ != "" && MemberIdEntered == "")
                {
                    MembershipIdTextBox.Enabled = false;
                    string FileSecondLine, FileFirstLine;
                    int i;

                    SearchResultListBox.Items.Clear();

                    StreamReader InputFile;
                    InputFile = File.OpenText("HaloFitnessAppRecord.txt");
                    while (!InputFile.EndOfStream)
                    {
                        FileFirstLine = InputFile.ReadLine();
                        FileSecondLine = InputFile.ReadLine();
                        if (FileSecondLine == DOJ)
                        {

                            SearchResultListBox.Items.Add(FileFirstLine);
                            SearchResultListBox.Items.Add(FileSecondLine);
                            for (i = 0; i < MEMBERRECORDLENGHT - 2; i++)
                            {
                                SearchResultListBox.Items.Add(InputFile.ReadLine());
                            }

                            SearchResultListBox.Items.Add("----------------*********************-----------");
                        }
                        else
                        {
                            for (i = 0; i < MEMBERRECORDLENGHT - 2; i++)
                            {
                                InputFile.ReadLine();
                            }
                        }

                    }
                    MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (SearchResultListBox.Items.Count == 0)
                    {
                        MessageBox.Show("Please enter the Valid Date of Joining", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    InputFile.Close();
                }
                else if (MembershipIdTextBox.Text == "" && DateOfJoiningTextBox.Text == "")
                {
                    MessageBox.Show("Please enter valid Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Pleaes enter Valid Input", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                }
                catch
                {
                    MessageBox.Show("Please enter the valid Membership ID", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            ResetButton.Focus();
            }   
        

        private void button1_Click(object sender, EventArgs e)
        {
            MembershipIdTextBox.Clear();
            DateOfJoiningTextBox.Clear();
            SearchResultListBox.Items.Clear();
            MembershipDetailsGroupBox.Visible = false;
            MembershipIdTextBox.Enabled = true;
            DateOfJoiningTextBox.Enabled = true;
            PricingGroupBox.Visible = false;
            SummaryGroupBox.Visible = false;
            SearchGroupBox.Visible = true;
            CommonSearchButton.Focus();

        }

        private void MembershipIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        const int INCREMENT = 2, FORMWIDTH = 954, FORMSTARTHEIGHT = 380, FORMEXPANDHEIGHT = 620;

        private void MainForm_Load(object sender, EventArgs e)
        {
            MembershipDetailsGroupBox.Visible = false;
            PricingGroupBox.Visible = false;
            SummaryGroupBox.Visible = false;
            SearchGroupBox.Visible = false;
            ButtonPanel.Visible = false;
            PasswordPanel.Visible = true;
            PasswordSubmitButton.Focus();
            PasswordTextBox.Select();
            
            this.Size = new Size(FORMWIDTH,FORMSTARTHEIGHT);
        }

        private void PasswordSubmitButton_Click(object sender, EventArgs e)
        {
            
            // calling the streamwriter to writing into the file.
            StreamWriter OutputFile;
            //if file not exists, create the file and append it. 
            if (!File.Exists("HaloFitnessAppRecord.txt"))
            {
                OutputFile = File.CreateText("HaloFitnessAppRecord.txt");
                OutputFile.Close();
            }
            String TempPassword;
            TempPassword= PasswordTextBox.Text;
            string PASSWORD= "ILuvVisualC#";
            NumberOfAttempts = NumberOfAttempts + 1;
            PasswordTextBox.Focus();
            PasswordTextBox.SelectAll();
            //decision construct of validating the password entered by user.
            if (NumberOfAttempts < MaximumAttempts)
            {
                if (TempPassword == PASSWORD)
                {
                    PasswordPanel.Visible = false;
                    PricingGroupBox.Visible = true;
                    ButtonPanel.Visible = true;
                }
                // Validating Number of attempts with maximum attempts. 
                else
                {
                    NumberOfAttemptsLeft = MaximumAttempts - NumberOfAttempts;
                    MessageBox.Show(string.Format("Please enter the valid password" + "\n" + "Number of attemts left is " + NumberOfAttemptsLeft), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PasswordTextBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show(string.Format("Maximum number of attempts reached" + "\n" + "Please try after sometime"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            DisplayButton.Focus();
            }




        private void DisplayButton_Click(object sender, EventArgs e)
        {

         
                    try
                    {
                        int Term = int.Parse(TermTextBox.Text);
                        // Decision construct for term and discount calculation.
                        if (Term > 0)
                        {
                            // Decision construct for the term 1 t0 2.
                            if (Term >= 1 && Term < 3)
                            {
                                Calculate(DISCOUNT0TO2, DISCOUNT3TO6, Term, NEXTSTARTTERM3);
                            }
                            //Decision construct for the term 3 t0 6.
                            else if (Term >= 3 && Term < 7)
                            {
                                Calculate(DISCOUNT3TO6, DISCOUNT7TO12, Term, NEXTSTARTTERM7);
                            }
                            //Decision construct for the term 7 t0 12.
                            else if (Term >= 7 && Term < 13)
                            {
                                Calculate(DISCOUNT7TO12, DISCOUNT13TO18, Term, NEXTSTARTTERM13);
                            }
                            //Decision construct for the term 13 t0 18.
                            else if (Term >= 13 && Term < 19)
                            {
                                Calculate(DISCOUNT13TO18, DISCOUNT19TO24, Term, NEXTSTARTTERM19);
                            }
                            //Decision construct for the term 19 t0 24.
                            else if (Term >= 19 && Term < 25)
                            {
                                Calculate(DISCOUNT19TO24, DISCOUNT25TO60, Term, NEXTSTARTTERM25);
                            }
                            //Decision construct for the term 25 t0 60.
                            else if (Term >= 25 && Term < 61)
                            {
                                Calculate(DISCOUNT25TO60, DISCOUNTABOVE60, Term, NEXTSTARTTERM60);
                            }
                            //Decision construct for the term above 60 .
                            else
                            {
                                Calculate(DISCOUNTABOVE60, DISCOUNTABOVE60, Term, NEXTSTARTTERM60);
                            }
                        }
                        //Decision construct for the term 0.
                        else
                        {
                            MessageBox.Show("Please enter  valid number of months", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                       
                    catch (Exception TermException)
                    {
                        MessageBox.Show(TermException.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                
                SummaryGroupBox.Visible = false;
                SearchGroupBox.Visible = false;
                MembershipDetailsGroupBox.Visible = false;
                ButtonPanel.Visible = true;
                ProceedButton.Focus();
            }
            
            

        private void Calculate(decimal TermDiscount, decimal NextTermDiscount, int SelectedTerm, decimal NextStartTerm)
        {
            //All the calculation will be done in this mwthod.
            PricePerMonth = Math.Round((BASEPRICE - (BASEPRICE * TermDiscount)),2);
            PriceForSelectedFullterm =Math.Round (PricePerMonth * SelectedTerm,2);
            PricePerMonthNextTerm =Math.Round((BASEPRICE - (BASEPRICE * NextTermDiscount)),2);
            PriceForNextFullTerm = Math.Round(PricePerMonthNextTerm * NextStartTerm,2);
            // the calculated values passed to display method by call by value.
            Display(PricePerMonth, PriceForSelectedFullterm, PriceForNextFullTerm, PricePerMonthNextTerm);
        }

        private void Display(decimal MonthlyPrice, decimal TermPrice, decimal NextTermPrice, decimal NextTermMonthlyPrice)
        {
            // values displayed in respected textboxes.
            PricePerMonthLabel.Text = "€" + MonthlyPrice.ToString();
            PriceFullTermLabel.Text = "€" + TermPrice.ToString();
            PriceNextTermLabel.Text = "€" + NextTermPrice.ToString();
            NextTermMonthlyPriceLabel.Text = "€" + NextTermMonthlyPrice.ToString();
            
        
        }

        private void ProceedButton_Click(object sender, EventArgs e)
        {

            try
            {
                ConfirmedTerm = int.Parse(ClientConfirmedTextBox.Text);

                if (ConfirmedTerm > 0)
                {
                    if (ConfirmedTerm >= 1 && ConfirmedTerm < 3)
                    {
                        Calculate(DISCOUNT0TO2, DISCOUNT3TO6, ConfirmedTerm, NEXTSTARTTERM3);

                    }
                    else if (ConfirmedTerm >= 3 && ConfirmedTerm < 7)
                    {
                        Calculate(DISCOUNT3TO6, DISCOUNT7TO12, ConfirmedTerm, NEXTSTARTTERM7);
                    }
                    else if (ConfirmedTerm >= 7 && ConfirmedTerm < 13)
                    {
                        Calculate(DISCOUNT7TO12, DISCOUNT13TO18, ConfirmedTerm, NEXTSTARTTERM13);
                    }
                    else if (ConfirmedTerm >= 13 && ConfirmedTerm < 19)
                    {
                        Calculate(DISCOUNT13TO18, DISCOUNT19TO24, ConfirmedTerm, NEXTSTARTTERM19);
                    }
                    else if (ConfirmedTerm >= 19 && ConfirmedTerm < 25)
                    {
                        Calculate(DISCOUNT19TO24, DISCOUNT25TO60, ConfirmedTerm, NEXTSTARTTERM25);
                    }
                    else if (ConfirmedTerm >= 25 && ConfirmedTerm < 61)
                    {
                        Calculate(DISCOUNT25TO60, DISCOUNTABOVE60, ConfirmedTerm, NEXTSTARTTERM60);
                    }
                    else if (ConfirmedTerm.ToString() == "")
                    {
                        MessageBox.Show("Please enter the valid term", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Calculate(DISCOUNTABOVE60, DISCOUNTABOVE60, ConfirmedTerm, NEXTSTARTTERM60);
                    }
                    string Temp;
                    // calling random number generation method.
                    RandomNumberGenerator(ref RandomNumber);
                    StreamReader InputFile;
                    InputFile = File.OpenText("HaloFitnessAppRecord.txt");
                    while (!InputFile.EndOfStream)
                    {
                        Temp = InputFile.ReadLine();
                        // To check and generate unique random number.
                        if (Temp == RandomNumber.ToString())
                        {
                            RandomNumberGenerator(ref RandomNumber);
                        }
                    }
                    InputFile.Close();
                    // displaying generated unique random number and joining date.
                    MembershipIDLabel.Text = RandomNumber.ToString();
                    JoinDayLabel.Text = JoiningDate.ToShortDateString();
                    // Visibility changes to Form layout. 
                    PricingGroupBox.Visible = true;
                    ButtonPanel.Visible = true;
                    MembershipDetailsGroupBox.Visible = true;
                    SummaryGroupBox.Visible = false;
                    SearchGroupBox.Visible = false;
                    TermTextBox.ResetText();
                    PricePerMonthLabel.ResetText();
                    PriceFullTermLabel.ResetText();
                    PriceNextTermLabel.ResetText();
                    NextTermMonthlyPriceLabel.ResetText();
                    DisplayButton.Enabled = false;
                    ProceedButton.Enabled = false;
                }
                else
                {
                    MessageBox.Show(" Please enter the valid terms", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ConfirmedTermException)
            {
                MessageBox.Show(ConfirmedTermException.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Shifting focus to confirm button.
            ConfirmButton.Focus();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                String MembershipID = MembershipIDLabel.Text;
                 
                String FullName = FullNameTextBox.Text;
                //decision construct for validating fullname is not empty.
                if (FullName != "")
                {
                    string TelephoneNumber = TelephoneTextBox.Text;
                    // checking weather telephone number is null and should be in 9 numbers)
                    if (TelephoneNumber != "" && TelephoneNumber.Length==9)
                    {
                        String EmailId = EmailTextBox.Text; 
                        // decision construct for validating EmailId.
                        if (EmailId.Contains("@") && (EmailTextBox.Text.EndsWith(".com") || EmailTextBox.Text.EndsWith(".ie")))
                        {
                            //message box confirms with following details and if you press Yes than record is saved in file.
                            if (MessageBox.Show(string.Format("Membership Id is " + RandomNumber + "\n" + "Joining Date is " + JoinDayLabel.Text + "\n" + "Your name is " + FullName + "\n" + "Phone number is " + TelephoneNumber + "\n" + "Email Id is " + EmailId + "\n" + "Term in Months is " + ConfirmedTerm + "\n" + "Term Cost is " + "€" + PriceForSelectedFullterm), "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                StreamWriter outputFile;
                                // append the customer record to file.
                                outputFile = File.AppendText("HaloFitnessAppRecord.txt");
                                outputFile.WriteLine(MembershipIDLabel.Text);
                                outputFile.WriteLine(JoiningDate.ToShortDateString());
                                outputFile.WriteLine(FullName);
                                outputFile.WriteLine(TelephoneNumber);
                                outputFile.WriteLine(EmailId);
                                outputFile.WriteLine(ConfirmedTerm);
                                outputFile.WriteLine(PriceForSelectedFullterm);
                                // close the file after appending.
                                outputFile.Close();
                                ConfirmButton.Enabled = false;
                                MessageBox.Show(string.Format("...... Sweat it Out...." + "\n" + "Welcome to HaloFitness"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                ProceedButton.Enabled = true;
                                DisplayButton.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid emailid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phone number cannot be empty and alphabets", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Full Name cannot be empty and should contains only alphabets", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception EmptyString)
            {
                MessageBox.Show(EmptyString.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // visibility changes to form layout.
            PricingGroupBox.Visible = true;
            MembershipDetailsGroupBox.Visible = true;
            SummaryGroupBox.Visible = false;
            SearchGroupBox.Visible = false;
            ClearButton.Focus();
        }
    

        private void ClearButton_Click(object sender, EventArgs e)
        {
            //Reset all values in textboxes and labels. 
            MembershipIDLabel.ResetText();
            JoinDayLabel.ResetText();
            FullNameTextBox.ResetText();
            TelephoneTextBox.ResetText();
            EmailTextBox.ResetText();
            ClientConfirmedTextBox.ResetText();
             MembershipIdTextBox.ResetText();
            DateOfJoiningTextBox.ResetText();
            PriceFullTermLabel.ResetText();
            TermTextBox.ResetText();
            PriceNextTermLabel.ResetText();
            PricePerMonthLabel.ResetText();
            TotalSubscriptionFeesLabel.ResetText();
            AverageSubscriptionFeesLabel.ResetText();
            AverageSubscriptionTermLabel.ResetText();
            MembershipIdListBox.Items.Clear();
            SearchResultListBox.Items.Clear();
            NextTermMonthlyPriceLabel.ResetText();
            DisplayButton.Enabled = true;
            ProceedButton.Enabled = true;
            ConfirmButton.Enabled = true;

            if ((SummaryGroupBox.Visible) || (SearchGroupBox.Visible))
                {
                    for (int i = 620; i > 380; i -= INCREMENT)
                    {
                        this.Size = new Size(FORMWIDTH, i);
                        this.Update();
                        System.Threading.Thread.Sleep(1);
                    }
                }
            // visibility changes to from layout.
            SummaryGroupBox.Visible = false;
            SearchGroupBox.Visible = false;
            MembershipDetailsGroupBox.Visible = false;
            PricingGroupBox.Visible = true;
            DisplayButton.Focus();
        }

        private void SummaryButton_Click(object sender, EventArgs e)
        {
            //clearing the old values in membership Id list box.
            MembershipIdListBox.Items.Clear();
            decimal TotalSubscriptionFees = 0;
            decimal AverageSubscriptionTerms = 0, AverageSubscriptionFees=0;
            int Transactions = 0, TotalTermSubscribed=0;
            int j, TemporaryVariable1=0;
            decimal TemporaryVariable2=0;
            // Visibility changes to form layout.
            SearchGroupBox.Visible = false;
            SummaryGroupBox.Visible = true;
            PricingGroupBox.Visible = false;
            MembershipDetailsGroupBox.Visible = false;
            ButtonPanel.Visible = true;

            for (int i = FORMSTARTHEIGHT; i < FORMEXPANDHEIGHT; i += INCREMENT)
            {
                this.Size = new Size(FORMWIDTH, i);
                this.Update();
                System.Threading.Thread.Sleep(1);
            }
            //calling streamwriter to search the membership Ids in the file.
            StreamReader InputFile;
            InputFile = File.OpenText("HaloFitnessAppRecord.txt");
            // Loopes through till it reaches end of the file.
            while (!InputFile.EndOfStream)
            {
                MembershipIdListBox.Items.Add(InputFile.ReadLine());
                Transactions = Transactions + 1;
                // loops next 4 lines
                for (j = 1; j <= 4; j++)
                {
                    InputFile.ReadLine();
                }
                // term value is stored in temporary variable1.
                TemporaryVariable1 =int.Parse(InputFile.ReadLine());
                TotalTermSubscribed = TotalTermSubscribed + TemporaryVariable1;
                // Subscription amount is stored in temporary variable 2 and added to totalSubscription fees every time.
                TemporaryVariable2 = decimal.Parse(InputFile.ReadLine());
                TotalSubscriptionFees = TotalSubscriptionFees + TemporaryVariable2;

                
            }
            InputFile.Close();
                TotalSubscriptionFeesLabel.Text = "€" + (Math.Round(TotalSubscriptionFees, 2)).ToString();
            // CalculateAverage method returns AverageSubscriptionFees value.
                AverageSubscriptionFees = CalculateAverage(TotalSubscriptionFees, Transactions);
                Math.Round(AverageSubscriptionFees,2);
                AverageSubscriptionFeesLabel.Text = "€ "+ AverageSubscriptionFees.ToString();
            // CalculateAverage method returns AverageSubscriptionTerm value.
                AverageSubscriptionTerms = CalculateAverage(TotalTermSubscribed, Transactions);
                Math.Round(AverageSubscriptionTerms,2);
                AverageSubscriptionTermLabel.Text = AverageSubscriptionTerms.ToString();
            ClearButton.Focus();
           
            
        }
        
    private void SearchButton_Click(object sender, EventArgs e)
        {
          // vsisibilty cahnges to form layout.
            SummaryGroupBox.Visible = false;
            SearchGroupBox.Visible = true;
            MembershipIdTextBox.Clear();
            DateOfJoiningTextBox.Clear();
            SearchResultListBox.Items.Clear();
            MembershipDetailsGroupBox.Visible = false;
            
            PricingGroupBox.Visible = false;
            
            SearchGroupBox.Visible = true;
            CommonSearchButton.Focus();

            MembershipIdTextBox.ResetText();
            DateOfJoiningTextBox.ResetText();
            
            for (int i = FORMSTARTHEIGHT; i < FORMEXPANDHEIGHT; i += INCREMENT)
            {
                this.Size = new Size(FORMWIDTH, i);
                this.Update();
                System.Threading.Thread.Sleep(1);
            }
            // focuses shift to CommonSearch Button.
            CommonSearchButton.Focus();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //Closes the application.
            this.Close();

        }
        
        private void RandomNumberGenerator(ref int number)
        {
            // method to generate random number.
            Random rd = new Random();
            number = rd.Next(100000, 999999);
        }
        private decimal CalculateAverage(decimal Fees, int Transaction)
        {
            // General Method to calculate Average values.
            decimal Average;
            return Average = Math.Round((Fees / Transaction),2);
        }
    }
}
