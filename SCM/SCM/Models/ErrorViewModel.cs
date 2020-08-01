namespace SCM.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }

        public void SetAsDomainRulesException()
        {
            this.DomainRulesException = true;
            this.BusinessLogicException = false;
        }

        public void SetAsBusinessLogicException()
        {
            this.BusinessLogicException = true;
            this.DomainRulesException = false;
        }        

        public string ErrorMessage { get; private set; }

        public bool DomainRulesException { get; private set; }
        public bool BusinessLogicException { get; private set; }
    }
}
