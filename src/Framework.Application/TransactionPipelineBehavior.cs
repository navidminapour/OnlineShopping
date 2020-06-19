using Framework.Core;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class TransactionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionPipelineBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //var scope = _scopeFactory.CreateScope();
            //var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            _unitOfWork.Begin();
            try
            {
                var response = await next();
                _unitOfWork.Commit();
                return response;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }


    //public class TransactionRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    //{
    //    private readonly IUnitOfWork _unitOfWork;

    //    public TransactionRequestPreProcessor(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }

    //    public async Task Process(TRequest request, CancellationToken cancellationToken)
    //    {
    //        _unitOfWork.Begin();
    //        await Task.FromResult(true);
    //    }
    //}


    //public class TransactionRequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    //{
    //    private readonly IUnitOfWork _unitOfWork;

    //    public TransactionRequestPostProcessor(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }

    //    public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
    //    {
    //        _unitOfWork.Commit();
    //        await Task.FromResult(true);
    //    }
    //}
}
