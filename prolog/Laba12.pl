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





