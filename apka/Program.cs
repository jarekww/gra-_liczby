using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

Random random = new Random();
int poziomTrudnosci;
int zakresGorny;
int secretNumber;
int liczbaGraczy;

List<int> liczbaProbGraczy = new List<int>();
int najlepszyWynik = int.MaxValue;

Console.WriteLine("Wybierz poziom trudności (1-łatwy, 2-średni, 3-trudny):");
if (!int.TryParse(Console.ReadLine(), out poziomTrudnosci) || poziomTrudnosci < 1 || poziomTrudnosci > 3)
{
    Console.WriteLine("Nieprawidłowy wybór, ustawiam poziom łatwy.");
    poziomTrudnosci = 1;
}

switch (poziomTrudnosci)
{
    case 1:
        zakresGorny = 50;
        break;
    case 2:
        zakresGorny = 100;
        break;
    case 3:
        zakresGorny = 200;
        break;
    default:
        zakresGorny = 100;
        break;
}

Console.WriteLine("Podaj liczbę graczy:");
if (!int.TryParse(Console.ReadLine(), out liczbaGraczy) || liczbaGraczy < 1)
{
    Console.WriteLine("Nieprawidłowa liczba graczy, ustawiam 1 gracza.");
    liczbaGraczy = 1;
}

for (int i = 0; i < liczbaGraczy; i++)
{
    liczbaProbGraczy.Add(0);
}

secretNumber = random.Next(1, zakresGorny + 1);
Console.WriteLine($"Zgadnij liczbę od 1 do {zakresGorny}.");

int aktualnyGracz = 0;
while (true)
{
    Console.WriteLine($"Gracz {aktualnyGracz + 1}, twoja kolej:");
    int guess;
    string input = Console.ReadLine();

    if (!int.TryParse(input, out guess))
    {
        Console.WriteLine("To nie jest liczba. Spróbuj ponownie.");
        continue;
    }

    liczbaProbGraczy[aktualnyGracz]++;

    if (guess == secretNumber)
    {
        Console.WriteLine($"Gracz {aktualnyGracz + 1} zgadł liczbę w {liczbaProbGraczy[aktualnyGracz]} próbach.");
        if (liczbaProbGraczy[aktualnyGracz] < najlepszyWynik)
        {
            najlepszyWynik = liczbaProbGraczy[aktualnyGracz];
        }
        break;
    }
    else if (guess < secretNumber)
    {
        Console.WriteLine("Za mało!");
    }
    else
    {
        Console.WriteLine("Za dużo!");
    }
    aktualnyGracz = (aktualnyGracz + 1) % liczbaGraczy;


  Console.WriteLine($"Najlepszy wynik to: {najlepszyWynik} prób.");
 Console.WriteLine("Koniec gry!");
 }

   

