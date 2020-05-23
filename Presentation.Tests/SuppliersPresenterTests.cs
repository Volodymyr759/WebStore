﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass()]
    public class SuppliersPresenterTests
    {
        private SuppliersPresenter suppliersPresenter;
        string errorMessage;

        public SuppliersPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            suppliersPresenter = new SuppliersPresenter(new SuppliersUC(errorMessageView),
                new SuppliersDetailPresenter(new SuppliersDetailUC(errorMessageView), ServicesInitializator.facade),
                ServicesInitializator.facade, 
                new DeleteConfirmView(), errorMessageView);
        }

        [TestMethod()]
        public void GetSuppliersUCTest_ShouldReturnSuppliersUC()
        {
            errorMessage = "";
            SuppliersUC suppliersUC = null;
            try
            {
                suppliersUC = (SuppliersUC)suppliersPresenter.GetSuppliersUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(suppliersUC, errorMessage);
        }
    }
}