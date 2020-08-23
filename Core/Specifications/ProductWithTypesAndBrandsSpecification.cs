using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(ProductSpecParams productParams) : base(p => 
        (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search)) && 
        (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId) && (!productParams.TypeId.HasValue || p.ProductTypeId==productParams.TypeId ))
        {
            AddInclude((p=>p.ProductBrand));
            AddInclude((p=>p.ProductType));
            AddOrderBy(p => p.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex-1),productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.Sort))
            {

                switch(productParams.Sort)
                {
                    
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;

                }
            }
            
        }

        public ProductWithTypesAndBrandsSpecification(int id) : base(p=>p.Id==id)
        {
            AddInclude((p=>p.ProductBrand));
            AddInclude((p=>p.ProductType));
        }
    }
}
