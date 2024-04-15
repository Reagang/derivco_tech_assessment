namespace Respository
{
    using Contracts;

    public class RepositoryManager: IRepositoryManager
    {
        private readonly DapperContext _context;
        private readonly Lazy<IBettingRepository> _bettingRepository;
        private readonly Lazy<IPaymentRepository> _paymentRepository;
        private readonly Lazy<IGameRepository> _gameRepository;
        public RepositoryManager(DapperContext context)
        {
            _context = context;
            _bettingRepository = new Lazy<IBettingRepository>(() => new BettingRepository(_context));
            _paymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(_context));
            _gameRepository = new Lazy<IGameRepository>(() => new GameRepository(_context));
        }
        public IBettingRepository Betting => _bettingRepository.Value;
        public IPaymentRepository Payment => _paymentRepository.Value;
        public IGameRepository Game => this._gameRepository.Value;
    }
}
