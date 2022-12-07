namespace Chtoto.Domain.Enteties.Repositories.Abstract
{
    public interface ITextFieldRepository
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldById(Guid id);
        TextField GetTextFieldByCodeWord(string CodeWord);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid id);
    }
}
