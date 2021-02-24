using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Vocabulary.Models
{
  public class Word
  {
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Length must be between 1 and 50 characters")]
    public string Rus { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Length must be between 1 and 50 characters")]
    public string Eng { get; set; }

    [Required]
    [Range(0, 5)]
    public int Points { get; set; }

    public bool IsLearned { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Language { get; set; }

    public int UserId { get; set; }

    [JsonIgnore]
    public User User { get; set; }

    public Word(string rus, string eng, int points = 0, string language = "en")
    {
      Rus = rus;
      Eng = eng;
      Points = points;
      IsLearned = false;
      Language = language;
    }

    public Word() { }

    public void CopyFrom(Word word)
    {
      Rus = word.Rus;
      Eng = word.Eng;
      Language = word.Language;
      Points = word.Points;
      IsLearned = word.IsLearned;
    }

    private string HandleString(string str)
    {
      if (char.IsLower(str[0]))
        return char.ToUpper(str[0]) + str.Substring(1, str.Length - 1);
      return str;
    }

    public void UpPoints()
    {
      if (Points < 5)
        ++Points;
    }

    public void DownPoints()
    {
      if (Points == 5)
        Points = 2;
      else if (Points > 0)
        --Points;
    }
  }
}
