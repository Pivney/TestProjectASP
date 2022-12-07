using Chtoto.Domain.Enteties.Repositories.Abstract;

namespace Chtoto.Domain
{
    public class DataManager
    {
        public ITextFieldRepository textFields { get; set; }
        public IServiceItemsRepository serviceItems { get; set; }

        public DataManager(ITextFieldRepository textFieldRepository, IServiceItemsRepository serviceItemsRepository)
        {
            textFields = textFieldRepository;
            serviceItems = serviceItemsRepository;
        }
    }
}
