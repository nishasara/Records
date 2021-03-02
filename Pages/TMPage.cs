using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Records.Pages
{
    class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            //Verify if user is able to add a new record into the table

            //Identify Create New button and Click on it
            IWebElement timeRecord = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            timeRecord.Click();
            Thread.Sleep(500);

            //Identify TypeCode button and Click on it
            IWebElement typeCode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            typeCode.Click();
            Thread.Sleep(500);

            //Select Time option from the TypeCode dropdown list
            IWebElement typeCodeTime = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            typeCodeTime.Click();
            Thread.Sleep(500);


            //Identify Code text box and input code
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.SendKeys("March21");
            Thread.Sleep(150);

            //Identify Description text box and input description
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.SendKeys("This record is for time for March21");
            Thread.Sleep(150);


            //Identify the Price text box and input the value
            IWebElement Price = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            //Price.Click();
            Thread.Sleep(150);
            Price.SendKeys("11.99");

            //Go to Select files to upload a file
            IWebElement selectFiles = driver.FindElement(By.Id("files"));
            selectFiles.SendKeys("D:\\File.txt");
            Thread.Sleep(500);

            //Identify Save button and click on it
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(1500);

            //Navigate to the last page
            IWebElement lastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPage.Click();
            Thread.Sleep(500);

            //Verify if each column value of the newly added record matches with the values keyed in
            IWebElement FirstColumnValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            String codeValue = FirstColumnValue.Text;

            if (codeValue == "March21")
                Console.WriteLine("Test Passed, Code value for the record created succesfully");

            IWebElement SecondColumnValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            String typeCodeValue = SecondColumnValue.Text;

            if (typeCodeValue == "T")
                Console.WriteLine("Test Passed, TypeCode value for the record created succesfully");

            IWebElement ThirdColumnValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            String descriptionValue = ThirdColumnValue.Text;

            if (descriptionValue == "This record is for time for March21")
                Console.WriteLine("Test Passed, Description value for the record created succesfully");

            IWebElement FourthColumnValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            String priceValue = FourthColumnValue.Text;

            if (priceValue == "$11.99")
                Console.WriteLine("Test Passed, Price value for the record created succesfully");

            if ((codeValue == "March21") && (typeCodeValue == "T") && (descriptionValue == "This record is for time for March21") && (priceValue == "$11.99"))
                Console.WriteLine("Test Passed, the new record is added successfully");
            else
                Console.WriteLine("Test Failed, the record is not added successfully");

            //Print the record values of the newly added record
            Console.WriteLine("The new record entry is as follows: ");
            Console.WriteLine("Code entered is: " + codeValue);
            Console.WriteLine("TypeCode entered is: " + typeCodeValue);
            Console.WriteLine("Description entered is: " + descriptionValue);
            Console.WriteLine("Price Per Unit entered is: " + priceValue);
        }

        public void EditTM(IWebDriver driver)
        {
            //Verify if the user is able to edit a record from the table (last record in the table)

            //Identify the last record in the last page and print its details
            IWebElement lastRecordInTable = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]"));
            String recordToBeEdited = lastRecordInTable.Text;
            Console.WriteLine("The record to be edited is" + recordToBeEdited);

            //Identify the edit button for the last record
            IWebElement Edit = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[last()]/a[1]"));

            //Click on the edit
            Edit.Click();
            Thread.Sleep(500);

            //Identify the TypeCode
            IWebElement typeCodeChange = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            typeCodeChange.Click();
            Thread.Sleep(500);

            //Change the TypeCode value to Material
            IWebElement typeCodeMaterial = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            typeCodeMaterial.Click();


            //Identify Code text box and edit the code value
            IWebElement codeEdit = driver.FindElement(By.Id("Code"));
            codeEdit.Clear();
            codeEdit.SendKeys("Feb21");
            Thread.Sleep(500);

            //Identify Description text box and input description
            IWebElement descriptionEdit = driver.FindElement(By.Id("Description"));
            descriptionEdit.Clear();
            descriptionEdit.SendKeys("This record is for Material for Feb21");
            System.Threading.Thread.Sleep(150);


            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            IWebElement PriceEdit = driver.FindElement(By.Id("Price"));
            PriceEdit.Clear();
            //driver.FindElement(By.Id("Price")).SendKeys("9999.99");

            //System.Threading.Thread.Sleep(150);
            //PriceEdit.SendKeys("9999.99");

            //Save the details after edit
            IWebElement saveAfterEdit = driver.FindElement(By.Id("SaveButton"));
            saveAfterEdit.Click();
            System.Threading.Thread.Sleep(1500);

            //Navigate to the last page
            IWebElement lastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPage.Click();

            //Delay
            System.Threading.Thread.Sleep(1500);

            lastRecordInTable = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]"));
            String editedRecord = lastRecordInTable.Text;
            Console.WriteLine("The edited record is" + editedRecord);

            //Validate if the recorded is edited correctly
            IWebElement FirstColumnVal = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            String codeVal = FirstColumnVal.Text;

            if (codeVal == "Feb21")
                Console.WriteLine("Test Passed, Code value for the record edited succesfully");

            IWebElement SecondColumnVal = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            String typeCodeVal = SecondColumnVal.Text;

            if (typeCodeVal == "M")
                Console.WriteLine("Test Passed, TypeCode value for the record edited succesfully");

            IWebElement ThirdColumnVal = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            String descriptionVal = ThirdColumnVal.Text;

            if (descriptionVal == "This record is for Material for Feb21")
                Console.WriteLine("Test Passed, Description value for the record edited succesfully");

            IWebElement FourthColumnVal = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            String priceVal = FourthColumnVal.Text;

            if (priceVal == "")
                Console.WriteLine("Test Passed, Price value for the record edited succesfully");

            if ((codeVal == "Feb21") && (typeCodeVal == "M") && (descriptionVal == "This record is for Material for Feb21") && (priceVal == ""))
                Console.WriteLine("Test Passed, the new record is edited successfully");
            else
                Console.WriteLine("Test Failed, the record is not edited successfully");
    }

        public void DeleteTM(IWebDriver driver)
        {
            //Verify if an existing user's record can be deleted

            System.Threading.Thread.Sleep(1500);

            //Identify the table that contains the record (this record is on the last page)
            IWebElement table = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table"));

            //Get the list of rows in the table for the last Page
            IList<IWebElement> Records = table.FindElements(By.TagName("tr"));

            //Get the count of total records in the last page
            int lastrowCount = Records.Count;

            IWebElement lastRow = Records[lastrowCount - 1];
            IList<IWebElement> columnsLastRow = lastRow.FindElements(By.TagName("td"));

            int columnCount = columnsLastRow.Count;

            //Delay
            System.Threading.Thread.Sleep(1500);

            String recordToBeDeleted = null;

            //Record to be deleted from the table
            //Randomly select a record to deleted (say the second row in the last page if the last page has more than 2 records)
            if (lastrowCount > 2)
                recordToBeDeleted = Records[1].Text;
            else if (lastrowCount == 2)
                recordToBeDeleted = Records[0].Text;
            else
                recordToBeDeleted = Records[0].Text;

            String currentText = null;
            bool rowDeleted = false;

            IWebElement rowToBeUpdated1 = null;
            IList<IWebElement> editDeleteElements1 = null;
            IList<IWebElement> columnsOfLastRow1 = null;

            //Loop through all the records until the record to be deleted is found
            for (int rowcounterUpdated = 0; rowcounterUpdated < lastrowCount; rowcounterUpdated++)
            {

                //Get the current record in String format
                currentText = Records[rowcounterUpdated].Text;

                //Check if the current record matches the record to be deleted
                bool stringEqual = currentText.Equals(recordToBeDeleted);

                //Delete the record if match is found
                if (stringEqual)
                {
                    Console.WriteLine("Record to be deleted found at row " + (rowcounterUpdated + 1));
                    rowToBeUpdated1 = Records[rowcounterUpdated];
                    columnsOfLastRow1 = rowToBeUpdated1.FindElements(By.TagName("td"));
                    editDeleteElements1 = columnsOfLastRow1[columnCount - 1].FindElements(By.TagName("a")); ;
                    editDeleteElements1[1].Click();
                    driver.SwitchTo().Alert().Accept();
                    rowDeleted = true;
                    break;

                }
                else
                {
                    Console.WriteLine("Record to be deleted not found at row" + (rowcounterUpdated + 1));
                    rowDeleted = false;
                }

            }

            System.Threading.Thread.Sleep(15000);
            table = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table"));
            IList<IWebElement> UpdatedRecords = table.FindElements(By.TagName("tr"));
            lastrowCount = UpdatedRecords.Count;

            //validate if the row is actually deleted from the table
            if (rowDeleted)
            {
                bool stringEqualInRow = false;
                for (int j = 0; j < lastrowCount; j++)
                {

                    currentText = UpdatedRecords[j].Text;
                    stringEqualInRow = currentText.Equals(recordToBeDeleted);
                    if (stringEqualInRow)
                    {
                        Console.WriteLine("Record is not deleted");
                        break;
                    }
                }
                if (!stringEqualInRow)
                    Console.WriteLine("Record is deleted successfully");

            }
            else
                Console.WriteLine("Record not found in current page");

        }

    }
}

