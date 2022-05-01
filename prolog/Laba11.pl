man(voeneg).
man(ratibor).
man(boguslav).
man(velerad).
man(duhovlad).
man(svyatoslav).
man(dobrozhir).
man(bogomil).
man(zlatomir).

woman(goluba).
woman(lubomila).
woman(bratislava).
woman(veslava).
woman(zhdana).
woman(bozhedara).
woman(broneslava).
woman(veselina).
woman(zdislava).

parent(voeneg,ratibor).
parent(voeneg,bratislava).
parent(voeneg,velerad).
parent(voeneg,zhdana).

parent(goluba,ratibor).
parent(goluba,bratislava).
parent(goluba,velerad).
parent(goluba,zhdana).

parent(ratibor,svyatoslav).
parent(ratibor,dobrozhir).
parent(lubomila,svyatoslav).
parent(lubomila,dobrozhir).


parent(boguslav,bogomil).
parent(boguslav,bozhedara).
parent(bratislava,bogomil).
parent(bratislava,bozhedara).

parent(velerad,broneslava).
parent(velerad,veselina).
parent(veslava,broneslava).
parent(veslava,veselina).

parent(duhovlad,zdislava).
parent(duhovlad,zlatomir).
parent(zhdana,zdislava).
parent(zhdana,zlatomir).

%11 ѕостроить предикат daughter(X, Y), который провер€ет,€вл€етс€ ли X
% дочерью Y. ѕостроить предикат, daughter(X), который выводит дочь X.
mother(X,Y):-parent(X,Y),woman(X).
daughter(X,Y):- mother(Y,X),woman(X).
daughter(X):- daughter(Y,X),write(Y),nl,fail.

% 12 ѕостроить предикат wife(X, Y), который провер€ет,
% €вл€етс€ ли X женой Y. ѕостроить предикат wife(X), который выводит
% жену X.
wife(X,Y):- parent(X,Z),parent(Y,Z),woman(X).
wife(X):-wife(Y,X),write(Y),!.

% 13 ѕостроить предикат grand_da(X, Y), который провер€ет,
%€вл€етс€ ли X внучкой Y. ѕостроить предикат grand_dats(X), который
%выводит всех внучек X.
grand_da(X,Y):-parent(Y,Z),parent(Z,X),woman(X).
grand_dats(X):-grand_da(Y,X),write(Y),nl,fail.

% 14 ѕостроить предикат grand_ma_and_da(X,Y),который провер€ет,
% €вл€ютс€ ли X и Y бабушкой и внучкой или внучкой и бабушкой.
grand_ma_da(X,Y):- grand_da(X,Y),woman(Y),!.
grand_ma_da(X,Y):-grand_da(Y,X),woman(X).

% 15
min(X,Y,X):-X<Y,!.
min(_,Y,Y).
mincifr(0,9):- !.
mincifr(N,M):-N1 is N div 10, mincifr(N1,Predmin),Cifr is N mod 10,min(Cifr,Predmin,M).
% 16 Ќайти минимальную цифру числа.–екурси€ вниз
min_cifr(N,M):-min_cifr(N,M,9).
min_cifr(0,X,X):-!.
min_cifr(N,X,C):-Cifr is N mod 10,
    NewN is N div 10,
    min(Cifr,C,Newmin),
    min_cifr(NewN,X,Newmin).
