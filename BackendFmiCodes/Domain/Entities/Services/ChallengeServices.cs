    using Domain.Entities;

    namespace Domain.Entities.Services;

    public class ChallengeServices
    {
        private readonly FmiDatabaseConfig _context;

        public ChallengeServices(FmiDatabaseConfig context)
        {
            _context = context;
        }

        public bool CreateChallenge(string email, string senderPath, string challengeCode, DateTime expireDate, int userId)
        {
            var challenge = new Challenge
            (
                challengeCode,
                "Pending",
                senderPath,
                expireDate,
                userId
            );

            _context.Challenges.Add(challenge);
            var result =  _context.SaveChanges();

            return result > 0;
        }
    }