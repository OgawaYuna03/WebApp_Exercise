using WebApp_Exercise.Exceptions;
namespace WebApp_Exercise.Applications.Domains;

public class Item
{
    public int? Id { get; private set; }
    public string? Name { get; private set; } = string.Empty;
    public int? Price { get; private set; } = 0;
    public ItemCategory? ItemCategory { get; private set; } = null;
    public ItemStock? ItemStock { get; private set; } = null;
    public Item(int? id, string? name, int? price)
    {
        ValidateId(id);
        ValidateName(name);
        ValidatePrice(price);
        Id = id;
        Name = name;
        Price = price;
    }
    public Item(string? name, int? price) : this(null, name, price) { }
    private void ValidateId(int? id)
    {
        if (id == null)
        {
            return;
        }
        if (id < 1)
        {
            throw new DomainException("商品Idは1以上でなければなりません。");
        }
    }
    private void ValidateName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new AppDomainUnloadedException("商品名は必須です。");
        if (name.Length > 30)
            throw new AppDomainUnloadedException("商品名は30文字以内で指定してください。");
    }
    private void ValidatePrice(int? price)
    {
        if (price == null)
        {
            return;
        }
        if (price < 0)
        {
            throw new DomainException("価格は0以上でなければなりません。");
        }
    }
    public void ChangeName(string? name)
    {
        ValidateName(name);
        Name = name;
    }

    /// <summary>
    /// 価格の変更
    /// </summary>
    public void ChangePrice(int price)
    {
        ValidatePrice(price);
        Price = price;
    }

    /// <summary>
    /// 商品カテゴリの変更
    /// </summary>
    public void ChangeProductCategory(ItemCategory? itemCategory)
    {
        ItemCategory = itemCategory;
    }

    /// <summary>
    /// 商品在庫の変更
    /// </summary>
    public void ChangeStock(ItemStock? stock)
    {
        ItemStock = stock;
    }

    /// <summary>
    /// 等価性の検証（Idが一致していれば同一とみなす）
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not Item other) return false;
        return Id == other.Id;
    }

    public override int GetHashCode() => Id?.GetHashCode() ?? 0;

    public override string ToString()
    {
        var idText = Id?.ToString() ?? "未登録";
        var nameText = string.IsNullOrWhiteSpace(Name) ? "未登録" : Name;
        var priceText = Price?.ToString() ?? "未登録";
        var categoryText = ItemCategory?.ToString() ?? "未登録";
        var stockText = ItemStock?.ToString() ?? "未登録";
        return $"商品Id={idText},商品名={nameText},単価={priceText},商品カテゴリ={categoryText},商品在庫={stockText}";
    }
}
