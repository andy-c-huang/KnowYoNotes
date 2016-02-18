using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using HelloWindows_Phone8.Resources;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO.IsolatedStorage;




public enum key{ A,B,C,D,E,F,G};
public enum type{ sharp, natural, flat};
public enum chordType{ maj, min};

public struct note{
    public key noteKey;
    public int level;
    public type noteType;
};

public struct chord{
    public key root;
    public chordType Type;
};

class NoteQuestion{

    private note[] answers = new note[4];//Fake Answers for the question
    private int answerIndex;//integer index
    private Random rand = new Random();
    private bool[] hashT = new bool[7];
    private int streak;
    private int lives;

    

    public NoteQuestion()
    {
        streak = 0;
        lives = 3;
        answerIndex = rand.Next(0, 4);//ranges between 0 and 3 inclusive

        answers[answerIndex].level = rand.Next(-1, 1);//values are -1 and 0

        switch (answers[answerIndex].level)
        {
            case -1:
                {
                    answers[answerIndex].noteKey = (key)(rand.Next(0, 5) + 2);
                    break;
                }
            case 0:
                {
                    answers[answerIndex].noteKey = (key)(rand.Next(0, 6) + 0);
                    break;
                }
        }

        answers[answerIndex].noteType = (type)(rand.Next(0, 3) + 0);
        for (int i = 0; i < 7; i = i + 1) { hashT[i] = false; }
            hashT[(int)answers[answerIndex].noteKey] = true;
        //set the other answers
        for (int i = 0; i < 4; i = i + 1)
        {
            if (i != answerIndex)
            {
                answers[i].noteType = answers[answerIndex].noteType;
                int temp1 = (rand.Next(0, 7));
                while (hashT[temp1]) { 
                    temp1 = (temp1 + 1) % 7;
                }
                hashT[temp1] = true;
                answers[i].noteKey = (key)temp1;
            }

        }//Pick a random note and random distinct fake answers
    }
    public bool testAnswer(int Input){
        if (Input == answerIndex)
        {
            streak = streak + 1;
            return true;
        }
        else
        {

            lives = lives - 1;
            return false;
        }
    }
    public void newQuestion(){

    int oldIndex = answerIndex;
    answerIndex = rand.Next(0,4);
    
    answers[answerIndex].level = ((((answers[oldIndex].level+rand.Next(-1,1))%2)+100)%2)-1;
    
    switch(answers[answerIndex].level){
        case -1:{
            int temp = ((int)answers[oldIndex].noteKey+rand.Next(0,5))%2 + 2;
            answers[answerIndex].noteKey = (key)(temp);
            break;
        }
        case 0:{
            int temp = ((int)answers[oldIndex].noteKey+rand.Next(0,6))%6;
            answers[answerIndex].noteKey = (key)(temp);
            break;
        }
    }
    
    
    answers[answerIndex].noteType = (type)((((((int)answers[oldIndex].noteType)+rand.Next(0,3))%3)+99)%3 + 0);
    for (int i = 0; i < 7; i = i + 1) { hashT[i] = false; }
    hashT[(int)answers[answerIndex].noteKey] = true;
    //set the other answers
    for (int i = 0; i < 4; i = i + 1)
    {
        if (i != answerIndex)
        {
            answers[i].noteType = answers[answerIndex].noteType;
            int temp1 = (rand.Next(0, 7));
            while (hashT[temp1])
            {
                temp1 = (temp1 + 1) % 7;
            }
            hashT[temp1] = true;
            answers[i].noteKey = (key)temp1;
        }

    }
    }//Redoes the question
    public note getAnswer(){
        note Temp;
        Temp.noteKey = answers[answerIndex].noteKey;
        Temp.level = answers[answerIndex].level;
        Temp.noteType = answers[answerIndex].noteType;
    
        return Temp;
    }

    public string getInput(int index){
        string input = "";
    
    switch(answers[index].noteType){
        case type.sharp:{
            input = input + "";
            break;
        }
        case type.flat:{
            input = input + "";
            break;
        }
        case type.natural:{
            break;
        }
        
    }
    switch(answers[index].noteKey){
        case key.A:{
            input =  "A" + input;
            break;
        }
        case key.B:{
            input = "B" + input;
            break;
        }
        case key.C:{
            input = "C" + input;
            break;
        }
        case key.D:{
            input = "D" + input;
            break;
        }
        case key.E:{
            input = "E" + input;
            break;
        }
        case key.F:{
            input = "F" + input;
            break;
        }
        case key.G:{
            input = "G" + input;
            break;
        }
    }
    return input;   
    }

    public int getIntScore()
    {
        return( (int)Math.Pow(2, streak-1) *10);
    }

    public string getScore()
    {
        int temp = (int)Math.Pow(2, streak-1) *10;
        string returnVal = "Score: " + temp.ToString();
        return returnVal;
    }

    public string getLives()
    {
        return ("Lives: " + lives.ToString());
    }


    public bool isAlive()
    {
        if (lives >= 0)
            return true;
        return false;
    }
};

class ChordQuestion{
    
};

class ScaleQuestion{
    
};



namespace HelloWindows_Phone8
{
    public partial class MainPage : PhoneApplicationPage
    {
        NoteQuestion Data = new NoteQuestion();

        private void HighScoreInitialize()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            // txtInput is a TextBox defined in XAML.
            if (!settings.Contains("HighScoreData"))
            {
                settings.Add("HighScoreData", 0);
            }
            settings.Save();
        }

        private void HighScoreUpdate(int CurrentScore)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            // txtInput is a TextBox defined in XAML.
            if (!settings.Contains("HighScoreData"))
            {
                settings.Add("HighScoreData", 0);
            }
            else
            {
                settings["HighScoreData"] = CurrentScore;
            }

            settings.Save();
        }

        public MainPage()
        {
            InitializeComponent();
            HighScoreInitialize();
            // countdown to start, replacing "get ready for it" key labels
            Problem();
        }



        private void Problem()
        {
            Data.newQuestion();
            note CurrentNote = Data.getAnswer();
            button0.Content = Data.getInput(0);
            button0.Background = new SolidColorBrush(Colors.Gray);
            button1.Content = Data.getInput(1);
            button1.Background = new SolidColorBrush(Colors.Gray); 
            button2.Content = Data.getInput(2);
            button2.Background = new SolidColorBrush(Colors.Gray); 
            button3.Content = Data.getInput(3);
            button3.Background = new SolidColorBrush(Colors.Gray); 
            DrawNote(CurrentNote);
            ScoreBox.Text = Data.getScore();
            LivesBox.Text = Data.getLives();
            if (!Data.isAlive()) 
            {
                int CurrentScore = Data.getIntScore();
                int CurrentHighScore = (int)IsolatedStorageSettings.ApplicationSettings["HighScoreData"];
                if (CurrentScore > CurrentHighScore)
                {
                    HighScoreUpdate(CurrentScore);       
                }
                NavigationService.Navigate(new Uri("/GameOverPage.xaml", UriKind.Relative));
            }
        }

        private void DrawNote(note CurrentNote)
        {

            CurrentNoteImage.Source = new BitmapImage(new Uri("/Assets/quarter_note.png", UriKind.Relative)); 
            // draw the note right-side-up again, by default

            if (CurrentNote.level == 0)
                {
                    if (CurrentNote.noteKey == key.B)
                        {
                            CurrentNoteImage.Source = new BitmapImage(new Uri("/Assets/quarter_note_flipped.png", UriKind.Relative)); 
                            CurrentNoteImage.Margin = new Thickness(202, 127, 186, 0);
                            myMediaElement.Source = new Uri("/Assets/B_0.mp3", UriKind.RelativeOrAbsolute);
                            myMediaElement.Play();
                        }
                    else
                    {
                        switch(CurrentNote.noteKey)
                        {
                            case key.C:
                                {
                                    CurrentNoteImage.Margin = new Thickness(202, 183, 186, 0);
                                    myMediaElement.Source = new Uri("/Assets/C_0.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.D:
                                {
                                    CurrentNoteImage.Margin = new Thickness(202,159,186,0);
                                    myMediaElement.Source = new Uri("/Assets/D_0.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.E:
                                {
                                    CurrentNoteImage.Margin = new Thickness(202, 135, 186, 0);
                                    myMediaElement.Source = new Uri("/Assets/E_0.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.F:
                                {
                                    CurrentNoteImage.Margin = new Thickness(202, 111, 186, 0);
                                    myMediaElement.Source = new Uri("/Assets/F_0.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.G:
                                {
                                    CurrentNoteImage.Margin = new Thickness(202, 87, 176, 0);
                                    myMediaElement.Source = new Uri("/Assets/G_0.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.A:
                                {
                                    CurrentNoteImage.Margin = new Thickness(202, 63, 186, 0);
                                    myMediaElement.Source = new Uri("/Assets/A_0.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                        }
                    }
                }
            else 
                {
                    switch (CurrentNote.noteKey) 
                    {
                        case key.C: {
                            CurrentNoteImage.Source = new BitmapImage(new Uri("/Assets/quarter_note_flipped.png", UriKind.Relative));
                            CurrentNoteImage.Margin = new Thickness(202, 105, 186, 0);
                            myMediaElement.Source = new Uri("/Assets/C_-1.mp3", UriKind.RelativeOrAbsolute);
                            myMediaElement.Play();
                            break;
                        }
                        case key.D:
                            {
                                CurrentNoteImage.Source = new BitmapImage(new Uri("/Assets/quarter_note_flipped.png", UriKind.Relative));
                                CurrentNoteImage.Margin = new Thickness(202, 81, 186, 0);
                                myMediaElement.Source = new Uri("/Assets/D_-1.mp3", UriKind.RelativeOrAbsolute);
                                myMediaElement.Play();
                                break;
                            }
                        case key.E:
                            {
                                CurrentNoteImage.Source = new BitmapImage(new Uri("/Assets/quarter_note_flipped.png", UriKind.Relative));
                                CurrentNoteImage.Margin = new Thickness(202, 57, 186, 0);
                                myMediaElement.Source = new Uri("/Assets/E_-1.mp3", UriKind.RelativeOrAbsolute);
                                myMediaElement.Play();
                                break;
                            }
                        case key.F:
                            {
                                CurrentNoteImage.Source = new BitmapImage(new Uri("/Assets/quarter_note_flipped.png", UriKind.Relative));
                                CurrentNoteImage.Margin = new Thickness(202, 33, 186, 0);
                                myMediaElement.Source = new Uri("/Assets/F_-1.mp3", UriKind.RelativeOrAbsolute);
                                myMediaElement.Play();
                                break;
                            }
                        case key.G:
                            {
                                CurrentNoteImage.Source = new BitmapImage(new Uri("/Assets/quarter_note_flipped.png", UriKind.Relative));
                                CurrentNoteImage.Margin = new Thickness(202, 9, 186, 0);
                                myMediaElement.Source = new Uri("/Assets/G_-1.mp3", UriKind.RelativeOrAbsolute);
                                myMediaElement.Play();
                                break;
                            }
                        case key.A:
                            {
                                CurrentNoteImage.Source = new BitmapImage(new Uri("/Assets/quarter_note_flipped.png", UriKind.Relative));
                                CurrentNoteImage.Margin = new Thickness(202, -15, 186, 0);
                                myMediaElement.Source = new Uri("/Assets/A_-1.mp3", UriKind.RelativeOrAbsolute);
                                myMediaElement.Play();
                                break;
                            }
                        case key.B:
                            {
                                CurrentNoteImage.Source = new BitmapImage(new Uri("/Assets/quarter_note_flipped.png", UriKind.Relative));
                                CurrentNoteImage.Margin = new Thickness(202, -39, 186, 0);
                                myMediaElement.Source = new Uri("/Assets/B_-1.mp3", UriKind.RelativeOrAbsolute);
                                myMediaElement.Play();
                                break;
                            }
                    }
                }

        }

        private void Button_Tap_0(object sender, GestureEventArgs e)
        {
            Button button = (Button)sender;
            if (Data.testAnswer(0))
            {
                button.Content = "Nice!";
                button.Background = new SolidColorBrush(Colors.Green);
                Problem();
            }
            else
            {
                button.Content = "Nope :(";
                button.Background = new SolidColorBrush(Colors.Red);
                Problem();
            }
        }

        private void Button_Tap_1(object sender, GestureEventArgs e)
        {
            Button button = (Button)sender;
            if (Data.testAnswer(1))
            {
                button.Content = "Nice!";
                button.Background = new SolidColorBrush(Colors.Green);
                Problem();
            }
            else
            {
                button.Content = "Nope :(";
                button.Background = new SolidColorBrush(Colors.Red);
                Problem();
            }
        }

        private void Button_Tap_2(object sender, GestureEventArgs e)
        {
            Button button = (Button)sender;
            if (Data.testAnswer(2))
            {
                button.Content = "Nice!";
                button.Background = new SolidColorBrush(Colors.Green);
                Problem();
            }
            else
            {
                button.Content = "Nope :(";
                button.Background = new SolidColorBrush(Colors.Red);
                Problem();
            }
        }

        private void Button_Tap_3(object sender, GestureEventArgs e)
        {
            Button button = (Button)sender;
            if (Data.testAnswer(3))
            {
                button.Content = "Nice!";
                button.Background = new SolidColorBrush(Colors.Green);
                Problem();
            }
            else
            {
                button.Content = "Nope :(";
                button.Background = new SolidColorBrush(Colors.Red);
                Problem();
            }
        }

        private void playSoundButton_click(object sender, RoutedEventArgs e)
        {

            {
                {
                    note TempNote = Data.getAnswer();
                    if (TempNote.level == 0)
                    {
                        switch (TempNote.noteKey)
                        {//Low notes
                            case key.C:
                                {
                                    myMediaElement.Source = new Uri("/Assets/C_0.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.D:
                                {
                                    myMediaElement.Source = new Uri("/Assets/D_0.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.E:
                                {
                                    myMediaElement.Source = new Uri("/Assets/E_0.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.F:
                                {
                                    myMediaElement.Source = new Uri("/Assets/F_0.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.G:
                                {
                                    myMediaElement.Source = new Uri("/Assets/G_0.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.B:
                                {
                                    myMediaElement.Source = new Uri("/Assets/B_0.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.A:
                                {
                                    myMediaElement.Source = new Uri("/Assets/A_0.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }

                        }
                    }
                    else
                    {
                        switch (TempNote.noteKey)
                        {//high notes
                            case key.C:
                                {
                                    myMediaElement.Source = new Uri("/Assets/C_-1.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.D:
                                {
                                    myMediaElement.Source = new Uri("/Assets/D_-1.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.E:
                                {
                                    myMediaElement.Source = new Uri("/Assets/E_-1.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.F:
                                {
                                    myMediaElement.Source = new Uri("/Assets/F_-1.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.G:
                                {
                                    myMediaElement.Source = new Uri("/Assets/G_-1.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.A:
                                {
                                    myMediaElement.Source = new Uri("/Assets/A_-1.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                            case key.B:
                                {
                                    myMediaElement.Source = new Uri("/Assets/B_-1.mp3", UriKind.RelativeOrAbsolute);
                                    myMediaElement.Play();
                                    break;
                                }
                        }

                    }
                }
            }
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}