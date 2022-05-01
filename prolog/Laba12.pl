 % ����� ������������ ������� �������� �����.
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


