GK_proj1 - edytor wielokątów i okręgów
Autor: Jakub Rymuza

---

Instrukcja obsługi:

- tworzenie wielokątu - naciśniecie przycisku 'Create New Polygon', a następnie klikanie LPM w kolejnych punktach tworząc wierzchołki. Klawisz 'ESC' zamyka wielokąt,
- tworzenie okręgu - naciśniecie przycisku 'Create New Circle' i wciśnięcie LPM w miejscu środka okręgu, a następnie przeciągnięcie by ustalić promień,
- przesuwanie wierzchołka - przeciągnięcie punktu trzymając LPM,
- usuwanie wierzchołka - naciśniecie przycisku 'Delete Point' i kliknięcie żadanego wierzchołka,
- dodawanie wierzchołka w środku wybranej krawędzi - naciśniecie przycisku 'Divide Edge' i kliknięcie żadanej krawędzi,
- przesuwanie całej krawędzi - przeciągnięcie krawędzi trzymając LPM,
- przesuwanie całego wielokąta - naciśniecie przycisku 'Drag Polygon' i przeciągnięcie dowolnego wierzchołka trzymając LPM,
- przesuwanie okręgu - przeciągnięcie środa okręgu trzymając LPM,
- zmiana promienia okręgu - przeciągnięcie krawędzi okręgu trzymając LPM,
- anulowanie akcji - naciśnięcie klawisza ESC,
- dodawanie relacji - naciśnięcie odpowiedniego przycisku relacji, a następnie kliknięcie w zależności od typu relacji 1 lub 2 obiektów (krawędzi, wierzchołków lub okręgów). W przypadku relacji o zadanej długości krawędzi lub okręgu należy równięż wprowadzić długość krawędzi/promienia do TextBoxa po wybraniu krawędzi i zatwierdzić ENTER,
- usuwanie relacji - naciśnięcie przycisku "Delete Relation", a następnie kliknięcie jednego z obiektów ograniczonego daną relacją, 
- generowanie sceny początkowej - przycisk "Generate Predefined" (jest ona również domyślnie generowana przy starcie programu).

---

Algorytm relacji:

Algorytm próbuje poprawiać kolejne wierzchołki, tak żeby dana relacja była nadal spełniona. Te z kolei również mogą powodować rekurencyjnie dalsze przesunięcia. Wprowadzono limit (20) przesunięć. Gdy zostaje osiągnięty program stwierdza że dane przesunięcie jest niemożliwe lokalnie i zamiast tego próbuje przesunąć całą figurę.

Relacja równych długości krawędzi - algorytm próbuje dopasować długość jednej krawędzi do drugiej bez zmiany ich kąta nachylenia. Przy przesuwaniu algorytm unika zmiany długości krawędzi.
Relacja o stałej długości krawędzi - algorytm próbuje narzucić określoną długość krawędzi, bez zmiany kąta nachylenia krawędzi.
Relacja o stałym punkcie (okrąg) - algorytm blokuje zmiany punktu środkowego okręgu.
Relacja o stałym promieniu - algorytm blokuje zmiany promienia okręgu.
Relacja prostopadłych krawędzi - mając krawędzie (v1,v2), (v3,v4) nowa pozycja dla v4 jest ustalana wg wzoru x4=y2-y1+x3, y4=x1-x2+y3 (czyli prostopadłe krawędzie mają równą długość). 
Relacja styczności - algorytm próbuje w pierwszej kolejności przesunąć okrąg w osi pionowej, tak by spełniona była relacja (ta relacja nie do końca działa w programie).

Program NIE posiada zabezpieczeń przed dodawaniem bezsensownych relacji (np. ograniczanie długości wierzchołka).