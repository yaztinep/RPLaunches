using OpenQA.Selenium;
using RPFramework.Business.Extensions;
using RPFramework.Core.Driver;

namespace RPFramework.Business.Pages
{
    public interface ILaunchesPage
    {
        void Action(string actionOption);
        void ClickOnAddFilterButton();
        void ClickOnDropdow();
        void ClickOnView(string viewName);
        void FindBuildNumber(string buildNumber, string filterValue, string keyValue);
        void SelectLaunches(int[] options);
        void SelectOption(string value);
    }

    public class LaunchesPage : ILaunchesPage
    {
        private readonly IDriverWait _idriverWait;

        public LaunchesPage(IDriverWait idriverWait)
        {
            _idriverWait = idriverWait;
        }

        private IWebElement addFilterButton => _idriverWait.FindElement(By.CssSelector("div.launchFiltersToolbar__add-filter-button--Hgtlm"));

        private IWebElement inputDropdownSorting => _idriverWait.FindElement(By.CssSelector("div.inputDropdownSorting__dropdown--E_Cma"));
        private IWebElement moreFilters => _idriverWait.FindElement(By.CssSelector("div.entitiesSelector__toggler--_p1QT"));
        private IWebElement key => _idriverWait.FindElement(By.CssSelector("input.singleAutocomplete__input--UgN6e"));
        private IWebElement keyAutoComplete => _idriverWait.FindElement(By.CssSelector("ul.autocompleteMenu__menu--xGfet"));
        private IWebElement value => _idriverWait.FindElement(By.CssSelector("input#downshift-1-input"));
        private IWebElement valueAutoComplete => _idriverWait.FindElement(By.CssSelector("ul.autocompleteMenu__opened--heQul"));
        private IWebElement checkIcon => _idriverWait.FindElement(By.CssSelector("div.attributeEditor__check-icon--KN6KY"));
        private List<IWebElement> filters => _idriverWait.FindElements(By.CssSelector("span.inputCheckbox__children-container--R83YO")).ToList();
        private List<IWebElement> sortOptions => _idriverWait.FindElements(By.CssSelector("div.inputDropdownSortingOption__dropdown-option--zBxBu")).ToList();
        private List<IWebElement> launchNumbers => _idriverWait.FindElements(By.CssSelector("span.itemInfo__number--uvCUK")).ToList();
        private IWebElement launchNameLink => _idriverWait.FindElement(By.CssSelector("a.itemInfo__name-link--oIaqj"));
        private IWebElement totalLink => _idriverWait.FindElement(By.CssSelector("a[statuses='PASSED,FAILED,SKIPPED,INTERRUPTED']"));
        private IWebElement passedLink => _idriverWait.FindElement(By.CssSelector("a[statuses='PASSED']"));
        private IWebElement failedLink => _idriverWait.FindElement(By.CssSelector("a[statuses='FAILED,INTERRUPTED']"));
        private IWebElement skippedLink => _idriverWait.FindElement(By.CssSelector("a[statuses='SKIPPED']"));
        private IWebElement productBugLink => _idriverWait.FindElement(By.CssSelector("div.launchSuiteGrid__pb-col--QoQdW div div"));
        private IWebElement autoBugLink => _idriverWait.FindElement(By.CssSelector("div.launchSuiteGrid__ab-col--cmhGC  div div"));
        private IWebElement systemIssueLink => _idriverWait.FindElement(By.CssSelector("launchSuiteGrid__si-col--yM7Bg div div"));
        private IWebElement toInvestigateLink => _idriverWait.FindElement(By.CssSelector("launchSuiteGrid__ti-col--qV5Sv div div"));
        private List<IWebElement> checkBoxes => _idriverWait.FindElements(By.CssSelector("div.checkIcon__square--Exwkc.checkIcon__centered--l8fuA")).ToList();
        private IWebElement actionsButton => _idriverWait.FindElement(By.CssSelector("div.ghostMenuButton__ghost-menu-button--xMrXq.ghostMenuButton__color-topaz--h0zMs"));
        private List<IWebElement> actionOptions => _idriverWait.FindElements(By.CssSelector("div.ghostMenuButton__menu-item--xC85S span")).ToList();
        public void ClickOnAddFilterButton()
        {
            addFilterButton.Click();
        }
        public void ClickOnDropdow()
        {
            inputDropdownSorting.Click();
        }

        public void SelectOption(string value)
        {
            foreach (IWebElement option in sortOptions)
            {
                if (option.Text == value)
                {
                    option.Click();
                    break;
                }
            }
        }

        public void FindBuildNumber(string buildNumber, string filterValue, string keyValue)
        {
            moreFilters.Click();
            foreach (IWebElement filter in filters)
            {
                if (filter.Text == filterValue)
                {
                    filter.Click();
                    break;
                }
            }
            key.SendText(keyValue);
            key.SendKeys(Keys.ArrowDown);
            keyAutoComplete.Click();
            key.SendKeys(Keys.Tab);
            value.SendText(buildNumber);
            value.SendKeys(Keys.ArrowDown);
            valueAutoComplete.Click();
            value.SendKeys(Keys.Tab);
            checkIcon.Click();
        }

        public void ClickOnView(string viewName)
        {
            switch (viewName.ToLower())
            {
                case "launch name":
                    launchNameLink.Click();
                    break;
                case "total":
                    totalLink.Click();
                    break;
                case "passed":
                    passedLink.Click();
                    break;
                case "failed":
                    failedLink.Click();
                    break;
                case "skipped":
                    skippedLink.Click();
                    break;
                case "product bug":
                    productBugLink.Click();
                    break;
                case "auto bug":
                    autoBugLink.Click();
                    break;
                case "system issue":
                    systemIssueLink.Click();
                    break;
                case "to investigate":
                    toInvestigateLink.Click();
                    break;
                default: break;

            }

        }

        public void SelectLaunches(int[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                int v = options[i] + 1;
                checkBoxes[v].Click();
            }
        }

        public void Action(string actionOption)
        {
            actionsButton.Click();

            foreach (IWebElement action in actionOptions)
            {
                if (action.Text == actionOption)
                {
                    action.Click();
                    break;
                }
            }
        }
    }
}
