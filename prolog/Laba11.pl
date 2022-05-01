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
