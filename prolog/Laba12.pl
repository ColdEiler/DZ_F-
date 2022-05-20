%11
max(X,Y,X):-X>Y,!.
max(_,Y,Y).

pr(1):-fail.
pr(X):-pr(X,2).
pr(X,X):-!.
pr(X,I):- 0 is X mod I,!,fail.
pr(X,I):-I1 is I+1,pr(X,I1).

max_pr_up(C,X):-maX_pr_up(C,C,X).
maX_pr_up(1,_,1):-!.
maX_pr_up(N,C,X):- 0 is C mod N,pr(N),!,N1 is N-1,maX_pr_up(N1,C,PredMax),max(N,PredMax,X).
maX_pr_up(N,C,X):-N1 is N-1,maX_pr_up(N1,C,X).

max_pr_d(N,X):-m(N,N,X,2).
m(_,2,X,X):-!.
m(N,Cur,X,M):-pr(Cur),0 is N mod Cur,!,max(M,Cur,L),N1 is Cur-1,m(N,N1,X,L).
m(N,Cur,X,M):-NewCur is Cur - 1,m(N,NewCur,X,M).

% 12 Найти НОД максимального нечетного непростого делителя числа и
% прозведения цифр данного числа.
nod(A,0,A):-!.
nod(A,B,X):- C is A mod B,nod(B,C,X).

prcifr(N,X):-pr(N,X,1).
pr(0,X,X):-!.
pr(N,X,P):-N1 is N div 10, Cifr is N mod 10, P1 is P * Cifr,pr(N1,X,P1).

max_nepr_del(N,X):-nd(N,N,X,1).
nd(_,1,X,X):-!.
nd(N,Cur,X,M):-not(pr(Cur)),0 is N mod Cur, 1 is Cur mod 2,!,max(M,Cur,L),N1 is Cur-1,nd(N,N1,X,L).
nd(N,Cur,X,M):-N1 is Cur -1,nd(N,N1,X,M).

task_12(N,X):- max_nepr_del(N,Y),prcifr(N,Z),nod(Y,Z,X).

%14
leng_l([],0):-!.
leng_l([_|T],X):-leng_l(T,PredX),X is PredX+1.

%15 1.10 Даны два массива. Необходимо найти количество совпадающих по
%значению элементов.
sovp(List,List1,X):-q(List,List1,X,0).
q([],_,X,X):-!.
q([H|T],List1,X,C):-q1(H,List1,NewC),N1 is NewC+C,q(T,List1,X,N1).
q1(_,[],0):-!.
q1(H,[HH|T],C):-q1(H,T,NewC),H=HH,!,C is NewC+1.
q1(H,[_|T],C):-q1(H,T,C).

%16 1.11 Дан целочисленный массив, в котором лишь один элемент отличается
%от остальных. Необходимо найти значение этого элемента.
in_list(List,El,X):-k(List,El,X,0).
k([],_,X,X):-!.
k([El|T],El,X,C):-!,NewC is C+1,k(T,El,X,NewC).
k([_|T],El,X,C):-k(T,El,X,C).

task_16(List,X):-t(List,List,X).
task16([],_,X,X):-!.
t([H|_],List,X):-in_list(List,H,1),!,task16([],List,H,X).
t([_|T],List,X):-t(T,List,X).
%17 1.21 Дан целочисленный массив. Необходимо найти элементы, расположенные
%после первого максимального.
max_List([H|T],X):- ml(T,X,H).
ml([],X,X):-!.
ml([H|T],X,M):-max(H,M,L),ml(T,X,L).

take_list([],X,X,_):-!.
take_list([El|T],List,X,El):-t_l(T,List,X),!.
take_list([_|T],L,X,El):-take_list(T,L,X,El).

t_l([],X,X):-!.
t_l([H|T],L,X):-append([H],L,K),t_l(T,K,X).
task_17(List,X):- max_List(List,M),take_list(List,[],X,M).

% 18 1.23 Дан целочисленный массив. Необходимо найти два наименьших
min(X,Y,X):-X<Y,!.
min(_,Y,Y).

min_list([H|T],X):-mil(T,X,H).
mil([],X,X):-!.
mil([H|T],X,M):-min(H,M,L),mil(T,X,L).

task_18(List,X,Y):-min_list(List,C),first(List,X,Y,C,[]).
first([],X,X,Y,Y):-!.
first([H|T],X,Y,C,List2):- append(L,List2,H),first(T,X,Y,C,L).
first([El|T],X,Y,El,List2):- append(L,List2,T),min_list(L,Y),first([],X,El,Y,Y),!.

%19 1.33 +- or -+
task_19([]):-!.
task_19([H|[R|_]]):- X is H*R, X>0,!,fail.
task_19([_|T]):-task_19(T).

% 20 1.36 Дан целочисленный массив. Необходимо найти максимальный
% нечетный элемент.
task_20([H|T],X):-s(T,X,H).
s([],X,X):-!.
s([H|T],X,M):- 1 is H mod 2,!,max(H,M,L),s(T,X,L).
s([_|T],X,M):-s(T,X,M).




























































