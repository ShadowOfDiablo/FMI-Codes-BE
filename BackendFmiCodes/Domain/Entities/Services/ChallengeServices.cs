    using Domain.Entities;

    namespace Domain.Entities.Services;

    public class ChallengeServices
    {
        private readonly FmiDatabaseConfig _context;

        public ChallengeServices(FmiDatabaseConfig context)
        {
            _context = context;
        }

        public int CreateChallenge(string email, string senderPath, string challengeCode, DateTime expireDate, int userId)
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
            if (result > 0)
            {
                return challenge.ChallengeId;
            }


            return -1; 
        }
    }