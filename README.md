HackyLambdas
============

I've made a very hacky untyped lambda calculus interpreter! wooo

I used the Sprache parser to parse the lambda terms. The lambda calculus is very left-recursive, so I got around this by using Sprache's operator capabilities to parse the functions and applications - viewing the period and the space as operators allows one to hackily get around the left recursion in the grammar. Surely there's a better way, but this is the fun way.

Using it
========

You can enter an expression, and it computes it for you:

```
>: (\x.x) y
~> y
```

You can also define terms:

```
>: true = \x.\y.x
~> defined true

>: true a b
~> a
```

Captivating

Contributing
============

Please feel free to contribute, in any way you want!
