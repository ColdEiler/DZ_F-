in_list([El|_], El).
in_list([_|Tail], El) :- in_list(Tail, El).

read_list(0, []) :- !.
read_list(I, [X|T]) :- read(X), I1 is I - 1, read_list(I1, T).

writelist([]) :- !.
writelist([X|T]) :- write(X), nl, writelist(T).

add([], X, X).
add([X|Y], Z, [X|W]) :- add(Y, Z, W).

% 1.39 Дан целочисленный массив. Необходимо вывести вначале его элементы с четными индексами, а затем - с нечетными.

%1.45
tas(List,A,B,Result):-t(List,A,B,[],Result).
t([],_,_,Result,Result).
t([H|T],A,B,CurList,Result):- H>A,H<B,!,add(CurList,[H],NewList),t(T,A,B,NewList,Result).
t([_|T],A,B,CurList,Result):-t(T,A,B,CurList,Result).

task_12():-write('List`s length is '),read(N),read_list(N,L),
    write('A is'), read(A),write('B is'),read(B),
    tas(L,A,B,R),writelist(R).
