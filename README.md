HackyLambdas
============

HackyLambdas is the final project for Lambda Calculus by Ian Wold and Paul Yon.

I used the Sprache parser to parse the lambda terms. The lambda calculus is very left-recursive, so I got around this by using Sprache's operator capabilities to parse the functions and applications - viewing the period and the space as operators allows one to hackily get around the left recursion in the grammar. Surely there's a better way, but this is the fun way.

Using it
========

HackyLambdas can do several things. First, it can beta-reduce and compute typing constraints for simply typed lambda calculus terms. In place of a lambda, a backslash is used. For example, one could input the following:

```
>: (\x:a.x) y
```

And HackyLambdas will beta-reduce it, as well as compute the typing constraints on the term.

You can define terms with HackyLambdas:

```
>: true = \a:a.\b:b.a
```

You can type in integers, and they will be translated into Church-encoded numerals automagically:

```
>: 5
```

HackyLambdas can convert any LC term to its corresponding DeBruijn notation:

```
>: debruijn
db>: \x:a.x
```

And HackyLambdas can check for alpha-equivalence between any two terms

```
>: alpha
a1>: \x:a.x
a2>: \y:b.y
```

Captivating
