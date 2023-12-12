using Discount.Application.Commands;
using Discount.Application.Mappers;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Handlers;

public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, CouponModel>
{
    private readonly IDiscountRepository _discountRepository;

    public CreateDiscountCommandHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }
    public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = DiscountMapper.Mapper.Map<Coupon>(request);
        await _discountRepository.CreateDiscount(coupon);
        var couponModel = DiscountMapper.Mapper.Map<CouponModel>(coupon);
        return couponModel;
    }
}