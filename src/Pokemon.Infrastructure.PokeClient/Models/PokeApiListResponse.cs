using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Infrastructure.PokeClient.Models
{
    public class PokeApiListResponse
    {
        public int count { get; set; }
        public string? next { get; set; }
        public string? previous { get; set; }
        public List<PokeApiListItem> results { get; set; } = new();
    }

    public class PokeApiListItem
    {
        public string name { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
    }

    public class PokeApiDetailResponse
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public int base_experience { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public bool is_default { get; set; }
        public List<AbilityWrapper> abilities { get; set; } = new();
        public List<TypeWrapper> types { get; set; } = new();
        public List<StatWrapper> stats { get; set; } = new();
        public List<MoveWrapper> moves { get; set; } = new();
        public Sprites sprites { get; set; } = new();

        public class AbilityWrapper
        {
            public Ability ability { get; set; } = new();
            public bool is_hidden { get; set; }
            public int slot { get; set; }
        }
        public class Ability { public string name { get; set; } = string.Empty; }

        public class TypeWrapper
        {
            public int slot { get; set; }
            public Type type { get; set; } = new();
        }
        public class Type { public string name { get; set; } = string.Empty; }

        public class StatWrapper
        {
            public int base_stat { get; set; }
            public int effort { get; set; }
            public Stat stat { get; set; } = new();
        }
        public class Stat { public string name { get; set; } = string.Empty; }

        public class MoveWrapper
        {
            public Move move { get; set; } = new();
        }
        public class Move { public string name { get; set; } = string.Empty; }

        public class Sprites
        {
            public string? front_default { get; set; }
        }
    }
}
