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

%11 ��������� �������� daughter(X, Y), ������� ���������,�������� �� X
% ������� Y. ��������� ��������, daughter(X), ������� ������� ���� X.
mother(X,Y):-parent(X,Y),woman(X).
daughter(X,Y):- mother(Y,X),woman(X).
daughter(X):- daughter(Y,X),write(Y),nl,fail.

% 12 ��������� �������� wife(X, Y), ������� ���������,
% �������� �� X ����� Y. ��������� �������� wife(X), ������� �������
% ���� X.
wife(X,Y):- parent(X,Z),parent(Y,Z),woman(X).
wife(X):-wife(Y,X),write(Y),!.

% 13 ��������� �������� grand_da(X, Y), ������� ���������,
%�������� �� X ������� Y. ��������� �������� grand_dats(X), �������
%������� ���� ������ X.
grand_da(X,Y):-parent(Y,Z),parent(Z,X),woman(X).
grand_dats(X):-grand_da(Y,X),write(Y),nl,fail.

% 14 ��������� �������� grand_ma_and_da(X,Y),������� ���������,
% �������� �� X � Y �������� � ������� ��� ������� � ��������.
grand_ma_da(X,Y):- grand_da(X,Y),woman(Y),!.
grand_ma_da(X,Y):-grand_da(Y,X),woman(X).

% 15
min(X,Y,X):-X<Y,!.
min(_,Y,Y).
mincifr(0,9):- !.
mincifr(N,M):-N1 is N div 10, mincifr(N1,Predmin),Cifr is N mod 10,min(Cifr,Predmin,M).
% 16 ����� ����������� ����� �����.�������� ����
min_cifr(N,M):-min_cifr(N,M,9).
min_cifr(0,X,X):-!.
min_cifr(N,X,C):-Cifr is N mod 10,
    NewN is N div 10,
    min(Cifr,C,Newmin),
    min_cifr(NewN,X,Newmin).

%17 ����� ������������ ���� �����, �� ��������� �� 5. �������� �����
prcifrnot_5(0,1):-!.
prcifrnot_5(N,Pr):-N1 is N div 10,Cifr is N mod 10, 0 is Cifr mod 5,!,
    prcifrnot_5(N1,Pr).
prcifrnot_5(N,Pr):-N1 is N div 10,prcifrnot_5(N1,Predpr),Cifr is N mod 10,Pr is Cifr*Predpr.
%18 ����� ������������ ���� �����, �� ��������� �� 5. �������� ����
prnot_5(N,X):-prnot_5(N,X,1).
prnot_5(0,X,X):-!.
prnot_5(N,X,Pr):-N1 is N div 10,Cifr is N mod 10, 0 is Cifr mod 5,!,
    prnot_5(N1,X,Pr).
prnot_5(N,X,Pr):-N1 is N div 10,Cifr is N mod 10,Newpr is Cifr*Pr,
    prnot_5(N1,X,Newpr).
%19 ��������� �������� �����
fib(1,1):-!.
fib(2,1):-!.
fib(N,X):-N1 is N-1,N2 is N-2,fib(N1,X1),fib(N2,X2),X is X1+X2.
% 20
fibn(N,X):-fibn(N,X,1,1,2).
fibn(N,X,_,X,N):-!.
fibn(N,X,F1,F2,C):-NewC is C+1,NewF1 is F2,NewF2 is F2+F1,
    fibn(N,X,NewF1,NewF2,NewC).












