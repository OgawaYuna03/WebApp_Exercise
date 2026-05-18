using System.Reflection.Metadata;
using WebApp_Exercise.Exceptions;

namespace WebApp_Exercise.Applications.Domains;

public class ItemCategory
{
    public int? Id { get; private set; }
    public string? Name { get; private set; } = string.Empty;

    public ItemCategory(int? id, string? name)
    {
        ValidateId(id);
        ValidateName(name);
        Id = id;
        Name = name;
    }
    public ItemCategory(int? id) : this(id, null) { }

    private void ValidateId(int? id)
    {
        if (id == null)
        {
            return;
        }
        if (id < 1)
        {
            throw new DomainException("商品カテゴリIdは1以上でなければなりません");
        }
    }
    private void ValidateName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("商品カテゴリ名は必須です。");
        }
        if (name.Length > 20)
        {
            throw new DomainException("商品カテゴリ名は20文字以内で指定してください。");
        }

    }
    public void ChangeName(string? name)
    {
        ValidateName(name);
        this.Name = name;
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not ItemCategory other) return false;
        return Id == other.Id;

    }

    public override string ToString()
    {
        var idText = Id?.ToString() ?? "未登録";
        var nameText = string.IsNullOrWhiteSpace(Name) ? "未登録" : Name;
        return $"商品カテゴリId={idText},商品カテゴリ名{nameText}";
    }
}