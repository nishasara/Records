using NUnit.Framework;
using OpenQA.Selenium;
using Records.Utilities;
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
            Wait.ElementPresent(driver, "XPath", "//*[@id='container']/p/a");
            IWebElement timeRecord = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            timeRecord.Click();
            Thread.Sleep(500);

            //Identify TypeCode button and Click on it
            Wait.ElementPresent(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]");
            IWebElement typeCode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            typeCode.Click();
            Thread.Sleep(500);

            //Select Time option from the TypeCode dropdown list
            Wait.ElementPresent(driver, "XPath", "//*[@id='TypeCode_listbox']/li[2]");
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

            if(codeValue == "March21")
              Assert.Pass("Test Passed, Code value for the record created succesfully");
            else
              Assert.Fail("Test Failed, Code value for the record not created succesfully");

            IWebElement SecondColumnValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            String typeCodeValue = SecondColumnValue.Text;

            if(typeCodeValue == "T")
              Assert.Pass("Test Passed, TypeCode value for the record created succesfully");
            else
              Assert.Fail("Test Failed, TypeCode value for the record not created succesfully");

            IWebElement ThirdColumnValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            String descriptionValue = ThirdColumnValue.Text;

            if(descriptionValue == "This record is for time for March21")
              Assert.Pass("Test Passed, Description value for the record created succesfully");
            else
              Assert.Fail("Test Failed, Description value for the record not created succesfully");

            IWebElement FourthColumnValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            String priceValue = FourthColumnValue.Text;

            if(priceValue == "$11.99")
              Assert.Pass("Test Passed, Price value for the record created succesfully");
            else
              Assert.Fail("Test Failed, Price value for the record not created succesfully");

            if ((codeValue == "March21") && (typeCodeValue == "T") && (descriptionValue == "This record is for time for March21") && (priceValue == "$11.99"))
              Assert.Pass("Test Passed, the new record is added successfully");
            else
              Assert.Fail("Test Failed, the new record is not added successfully");
        }

        public void EditTM(IWebDriver driver)
        {
            //Navigate to the last page
            IWebElement lastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPage.Click();
            Thread.Sleep(1500);

            //Verify if the user is able to edit a record from the table (last record in the table)
            
            //Identify the last record in the last page and print its details
            IWebElement lastRecordInTable = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]"));
            String recordToBeEdited = lastRecordInTable.Text;
            Console.WriteLine("The record to be edited is" + recordToBeEdited);

            //Identify the edit button for the last record
            IWebElement Edit = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[last()]/a[1]"));

            //Click on the edit
            Edit.Click();
            Thread.Sleep(1500);

            //Identify the TypeCode
            IWebElement typeCodeChange = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            typeCodeChange.Click();
            Thread.Sleep(500);

            //Change the TypeCode value to Material
            IWebElement typeCodeMaterial = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            typeCodeMaterial.Click();
            Thread.Sleep(500);

            //Identify Code text box and edit the code value
            IWebElement codeEdit = driver.FindElement(By.Id("Code"));
            codeEdit.Clear();
            codeEdit.SendKeys("Feb21");
            Thread.Sleep(1500);

            //Identify Description text box and input description
            IWebElement descriptionEdit = driver.FindElement(By.Id("Description"));
            descriptionEdit.Clear();
            descriptionEdit.SendKeys("This record is for Material for Feb21");
            System.Threading.Thread.Sleep(1500);


            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            IWebElement PriceEdit = driver.FindElement(By.Id("Price"));
            PriceEdit.Clear();
            //driver.FindElement(By.Id("Price")).SendKeys("9999.99");

            //System.Threading.Thread.Sleep(150);
            //PriceEdit.SendKeys("9999.99");

            //Save the details after edit
            IWebElement saveAfterEdit = driver.FindElement(By.Id("SaveButton"));
            System.Threading.Thread.Sleep(1500);
            saveAfterEdit.Click();
            System.Threading.Thread.Sleep(1500);

            //Navigate to the last page
            lastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPage.Click();

            //Delay
            System.Threading.Thread.Sleep(2000);

            lastRecordInTable = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]"));
            String editedRecord = lastRecordInTable.Text;
            

            System.Threading.Thread.Sleep(1500);
            //Validate if the recorded is edited correctly by checking each column values
            IWebElement FirstColumnVal = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            String codeVal = FirstColumnVal.Text;

            if (codeVal == "Feb21")
                Assert.Pass("Test Passed, Code value for the record edited succesfully");
            else
                Assert.Fail("Test Failed, Code value for the record not edited succesfully");

            IWebElement SecondColumnVal = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            String typeCodeVal = SecondColumnVal.Text;

            if(typeCodeVal == "M")
                Assert.Pass("Test Passed, typeCode value for the record edited succesfully");
            else
                Assert.Fail("Test Failed, typeCode value for the record not edited succesfully");

            IWebElement ThirdColumnVal = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            String descriptionVal = ThirdColumnVal.Text;

            if(descriptionVal == "This record is for Material for Feb21")
                Assert.Pass("Test Passed, description value for the record edited succesfully");
            else
                Assert.Fail("Test Failed, description value for the record not edited succesfully");

            //Console.WriteLine("Test Passed, Description value for the record edited succesfully");

            IWebElement FourthColumnVal = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            String priceVal = FourthColumnVal.Text;

            if(priceVal == "")
              Assert.Pass("Test Passed, price value for the record edited succesfully");
            else
              Assert.Fail("Test Failed, price value for the record not edited succesfully");

            if((codeVal == "Feb21") && (typeCodeVal == "M") && (descriptionVal == "This record is for Material for Feb21") && (priceVal == ""))
                Assert.Pass("Test Passed, the new record is edited successfully");
            else
                Assert.Fail("Test Failed, the record is not edited successfully");
    }

        public void DeleteTM(IWebDriver driver)
        {

            //Navigate to the last page
            IWebElement lastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPage.Click();

            //Verify if an existing user's record can be deleted

            System.Threading.Thread.Sleep(1500);

            //Identify the table that contains the record (this record is on the last page)
            IWebElement table = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table"));

            //Get the list of rows in the table for the last Page
            IList<IWebElement> Records = table.FindElements(By.TagName("tr"));

            //Get the count of total records in the last page
            int lastrowCount = Records.Count;

            //Retrieve the last row in the table
            IWebElement lastRow = Records[lastrowCount - 1];

            //Retrieve the columns of the last row by tag id 'td'
            IList<IWebElement> columnsLastRow = lastRow.FindElements(By.TagName("td"));

            int columnCount = columnsLastRow.Count;

            //Delay
            System.Threading.Thread.Sleep(1500);

            IWebElement recordToBeDeleted = null;
            string RecordDeleted = null;

            //Locate the last record (this is the record to be deleted)
            recordToBeDeleted = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]"));
            RecordDeleted = recordToBeDeleted.Text;

            IList<IWebElement> editDelete = null;
            IList<IWebElement> columnsOfLastRecord = null;

            //Locate the Delete button
            columnsOfLastRecord = recordToBeDeleted.FindElements(By.TagName("td"));
            editDelete = columnsOfLastRecord[columnCount - 1].FindElements(By.TagName("a")); ;
            editDelete[1].Click();
            driver.SwitchTo().Alert().Accept();

            System.Threading.Thread.Sleep(1500);
            //Locate the updated table
            table = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table"));

            //Retrieve the Updated records after the delete is performed
            IList<IWebElement> UpdatedRecords = table.FindElements(By.TagName("tr"));
            lastrowCount = UpdatedRecords.Count;

            String currentText = null;

            //Validate if the record is deleted
            bool recordDeleted = true;
            for (int rowcount = 0; rowcount < lastrowCount; rowcount++)
            {

                currentText = UpdatedRecords[rowcount].Text;
                if (currentText.Equals(RecordDeleted))

                {
                    Console.WriteLine("Record is not deleted");
                    recordDeleted = false;
                    break;

                }
            }
            if(recordDeleted)
              Assert.Pass("Test passed, Record is deleted successfully");
            else
              Assert.Fail("Test Failed, Record is not deleted successfully");



        }

    }
}

