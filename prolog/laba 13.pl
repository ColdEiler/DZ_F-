in_list([El|_], El).
in_list([_|Tail], El) :- in_list(Tail, El).

read_list(0, []) :- !.
read_list(I, [X|T]) :- read(X), I1 is I - 1, read_list(I1, T).

writelist([]) :- !.
writelist([X|T]) :- write(X), nl, writelist(T).

add([], X, X).
add([X|Y], Z, [X|W]) :- add(Y, Z, W).

%11 1.39
y(List,A,B):-take(List,A,B,[],[],0).
take([],A,B,A,B,_):-!.
take([H|T],A,B,X,Y,C):-0 is C mod 2,!,C1 is C+1,add(X,[H],X1),take(T,A,B,X1,Y,C1).
take([H|T],A,B,X,Y,C):-C1 is C+1,add(Y,[H],Y1),take(T,A,B,X,Y1,C1).

task_11():-write('List`s length is '),read(N),read_list(N,L),y(L,A,B),writelist(A),nl,writelist(B).

%12 1.45
tas(List,A,B,Result):-t(List,A,B,[],Result).
t([],_,_,Result,Result).
t([H|T],A,B,CurList,Result):- H>A,H<B,!,add(CurList,[H],NewList),t(T,A,B,NewList,Result).
t([_|T],A,B,CurList,Result):-t(T,A,B,CurList,Result).

task_12():-write('List`s length is '),read(N),read_list(N,L),
    write('A is'), read(A),write('B is'),read(B),
    tas(L,A,B,R),writelist(R).
% 13 1.57

s_p(List,C,X):-sum_pred(List,0,C,0,X).
sum_pred(_,C,C,X,X):-!.
sum_pred([H|T],Cur,C,Sum,X):-S is Sum+H,Cur1 is Cur+1,sum_pred(T,Cur1,C,S,X).

k(List,X):-kolvo(List,List,0,X,0).
kolvo([],_,X,X,_):-!.
kolvo([H|T],List,L,X,C):-s_p(List,C,Sum),H>Sum,!,L1 is L+1,C1 is C+1,kolvo(T,List,L1,X,C1).
kolvo([_|T],List,L,X,C):-C1 is C+1,kolvo(T,List,L,X,C1).

task_13():-write('List`s length is '),read(N),read_list(N,L),k(L,X),nl,write(X).
%14
task_14():-
    Hair=[_,_,_],
    in_list(Hair,[belokurov,_]),
    in_list(Hair,[chernov,_]),
    in_list(Hair,[rishov,_]),
    in_list(Hair,[_,red]),
    in_list(Hair,[_,blond]),
    in_list(Hair,[_,brunete]),
    not(in_list(Hair,[belokurov,blond])),
    not(in_list(Hair,[belokurov,brunete])),
    not(in_list(Hair,[rishov,red])),
    not(in_list(Hair,[chernov,brunete])),
    write(Hair),!.

task_15():-
    Dress=[_,_,_],
    in_list(Dress,[valya,_,_]),
    in_list(Dress,[anya,_,_]),
    in_list(Dress,[natasha,_,_]),
    in_list(Dress,[_,white,_]),
    in_list(Dress,[_,green,_]),
    in_list(Dress,[_,blue,_]),
    in_list(Dress,[_,_,white]),
    in_list(Dress,[_,_,green]),
    in_list(Dress,[_,_,blue]),
    in_list(Dress,[anya,A,A]),
    not(in_list(Dress,[valya,white,white])),
    in_list(Dress,[natasha,_,green]),
    write(Dress),!.
%Surname,work,Kolvo brothers,Age
task_16():-
    Factory=[_,_,_,_],
    in_list(Factory,[_,slesar,0,0]),
    in_list(Factory,[_,tokar,_,0]),
    in_list(Factory,[_,svar,_,_]),
    in_list(Factory,[borisov,_,1,_]),
    in_list(Factory,[ivanov,_,_,_]),
    in_list(Factory,[semenov,_,_,2]),
    in_list(Factory,[Person1,slesar,_,_]),
    in_list(Factory,[Person2,tokar,_,_]),
    in_list(Factory,[Person3,svar,_,_]),
    write('slesar='),write(Person1),nl,
    write('tokar='),write(Person2),nl,
    write('svarshik='),write(Person3),!.
task_18():-
    People=[_,_,_,_],
    in_list(People,[voronov,_]),
    in_list(People,[pavlov,_]),
    in_list(People,[levitskiy,_]),
    in_list(People,[saharov,_]),
    in_list(People,[_,dancer]),
    in_list(People,[_,singer]),
    in_list(People,[_,artist]),
    in_list(People,[_,writer]),
    not(in_list(People,[voronov,singer])),
    not(in_list(People,[levitskiy,singer])),
    not(in_list(People,[pavlov,artist])),
    not(in_list(People,[pavlov,writer])),
    not(in_list(People,[saharov,writer])),
    not(in_list(People,[voronov,writer])),
    not(in_list(People,[voronov,artist])),
    write(People),!.

sprava(_,_,[_]):-fail.
sprava(A,B,[A|[B|_]]).
sprava(A,B,[_|List]):-sprava(A,B,List).

sleva(_,_,[_]):-fail.
sleva(A,B,[B|[A|_]]).
sleva(A,B,[_|List]):-sleva(A,B,List).

between(X,A,B,List):-sleva(X,A,List),sprava(X,B,List).
between(X,A,B,List):-sleva(X,B,List),sprava(X,A,List).

around(A,B,List):-sprava(A,B,List).
around(A,B,List):-sleva(A,B,List).

task_17():-
    Drinks=[_,_,_,_],
    in_list(Drinks,[bottle,_]),
    in_list(Drinks,[glass,_]),
    in_list(Drinks,[kuvshin,_]),
    in_list(Drinks,[bank,_]),
    in_list(Drinks,[bottle,_]),
    in_list(Drinks,[_,milk]),
    in_list(Drinks,[_,lemonade]),
    in_list(Drinks,[_,kvas]),
    in_list(Drinks,[_,water]),
    not(in_list(Drinks,[bottle,water])),
    not(in_list(Drinks,[bottle,milk])),
    not(in_list(Drinks,[bank,lemonade])),
    not(in_list(Drinks,[bank,water])),
    between([_,lemonade],[kuvshin,_],[_,kvas],Drinks),
    around([glass,_],[bank,_],Drinks),
    around([glass,_],[_,milk],Drinks),
    write(Drinks),!.

% Name,sport,Nation,place
task_19():-
    Sportsmen=[_,_,_],
    in_list(Sportsmen,[michael,basketball,_,2]),
    in_list(Sportsmen,[saimon,_,israel,_]),
    in_list(Sportsmen,[richard,_,_,_]),
    in_list(Sportsmen,[_,tennis,_,3]),
    in_list(Sportsmen,[_,criket,_,1]),
    in_list(Sportsmen,[_,_,america,_]),
    in_list(Sportsmen,[_,_,australia,_]),
    not(in_list(Sportsmen,[michael,_,america,_])),
    not(in_list(Sportsmen,[saimon,tennis,_,_])),
    in_list(Sportsmen,[Person,_,australia,_]),
    in_list(Sportsmen,[richard,Sport,_,_]),
    write('Australian is '),write(Person),nl,
    write('Richard`s sport is '),write(Sport),!.












