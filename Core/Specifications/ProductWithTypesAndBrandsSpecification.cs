using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification()
        {
            AddInclude((p=>p.ProductBrand));
            AddInclude((p=>p.ProductType));
        }

        public ProductWithTypesAndBrandsSpecification(int id) : base(p=>p.Id==id)
        {
            AddInclude((p=>p.ProductBrand));
            AddInclude((p=>p.ProductType));
        }
    }
}
