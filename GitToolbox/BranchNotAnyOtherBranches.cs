using System;
using System.Linq;

using LibGit2Sharp;

namespace GitToolbox
{
    public class BranchNotAnyOtherBranches
    {
        private readonly string _BranchName;

        public BranchNotAnyOtherBranches(string branchName)
        {
            _BranchName = branchName;
        }

        public void Execute()
        {
            var repo = new Repository(Environment.CurrentDirectory);

            var branchName = _BranchName;
            if (branchName == string.Empty)
                branchName = repo.Head.FriendlyName;

            var branch = repo.Branches.FirstOrDefault(b => b.FriendlyName == branchName);
            if (branch == null)
                throw new InvalidOperationException($"unknown branch '{_BranchName}'");

            var otherBranches = repo.Branches.Where(b => b.FriendlyName != branch.FriendlyName && b.FriendlyName != branch.TrackedBranch.FriendlyName).ToList();
            if (otherBranches.Count == 0)
                throw new InvalidOperationException("no other branches");

            var parameters = $@"""{branch.FriendlyName}"" --not " + string.Join(" ", otherBranches.Select(b => "\"" + b.FriendlyName + "\""));
            Console.WriteLine(parameters);
        }
    }
}