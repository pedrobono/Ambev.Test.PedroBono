namespace Ambev.Test.PedroBono.Domain.Entities
{
    internal interface ICardProduct
    {
        Product Product { get; set; }
        int ProductId { get; set; }
        Cart Cart { get; set; }
        int CartId { get; set; }
        int Qty { get; set; }
    }
}