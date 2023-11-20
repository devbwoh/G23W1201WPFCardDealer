using G23W1201WPFCardDealer;
using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

public class CardViewModel : INotifyPropertyChanged {
	private CardModel Card = new();

    // propfull 입력 후 Tab 두 번
    private string[] _cardResource;

    public CardViewModel() {
        _cardResource = new string[Card.Cards.Length];

        GetResourceName();

        OnPropertyChanged(nameof(CardResource));
    }

    public string[] CardResource {
		get { return _cardResource; }
	}

    public void Shuffle() {
        Card.Shuffle();

        GetResourceName();

        OnPropertyChanged(nameof(CardResource));
    }

    private void GetResourceName() {
        for (int i = 0; i < _cardResource.Length; i++)
            _cardResource[i] = GetCardName(Card.Cards[i]);
    }

    // 파일명 앞에 "Images/" 추가되었으니 주의할 것
    private string GetCardName(int c) {
        if (c < 0)
            return "Images/black_joker.png";

        string suit = "";
        switch (c / 13) {
            case 0: suit = "spades"; break;
            case 1: suit = "diamonds"; break;
            case 2: suit = "hearts"; break;
            case 3: suit = "clubs"; break;
        }

        string rank = "";
        switch (c % 13) {
            case 0: rank = "ace"; break;
            case int n when (n > 0 && n < 10):
                rank = (c % 13 + 1).ToString(); break;
            case 10: rank = "jack"; break;
            case 11: rank = "queen"; break;
            case 12: rank = "king"; break;
        }

        //--------------------------------------------
        // Jack, Queen, King일 때 suit 뒤에 2 붙이기
        //--------------------------------------------
        // 방법 0. Windows Forms 때처럼 rank switch 문에서 suit에 "2" 추가

        // 방법 1. Contains 사용
        //if (new int[] { 10, 11, 12 }.Contains(c % 13))

        // 방법 2. IndexOf(), FindIndex() 함수 사용해도 됨

        // 방법 3. Lambda Expression을 사용하여 c % 13 값이 10, 11, 12와 일치하는지 검사
        if (Array.Exists(new int[] { 10, 11, 12 }, x => x == c % 13))
            return string.Format("Images/{0}_of_{1}2.png", rank, suit);
        else
            return string.Format("Images/{0}_of_{1}.png", rank, suit);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    // propName에 "CardResource"가 넘어감
    protected void OnPropertyChanged(string propName = "") {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
