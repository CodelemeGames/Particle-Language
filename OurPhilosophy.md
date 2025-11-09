**Our Programming Philosophy**

The core of particle is it's inclusion of a different philosophy to writing code than in C or C++. It takes notes from Rust's approach for memory management and some standardised conventions to code structure.

We will also explain under each pillar nd rule why it was suitable and later chosen.

**1. Use only raw pointers when you have absolutely no alternative to the functionality you require.**

Raw pointers give lots of control to programmers, but they also pose some of the largest risks when writing software at a low-level. Security issues such as use-after-frees or dangling pointers are mostly caused by mishandling of these kinds of pointers. Therefore they should only be used in small-scale instances or highly monitored environments where the programmer knows exactly when a raw pointer is allocated and freed. 

Over time, languages such as C++ have been given newer solutions to heap allocated memory - such as smart pointers. However, since it is exclusive to the language, we highly recommend using stack memory which manages its own lifetime for as long as you possibly can if you are not targeting C++ - though remember that you should still try and track allocations in general as it keeps a firm grasp on the codebase.

In safe particle code environments (environments in which the transpiler has not been told to allow unsafe code), we have the transpiler look for any raw pointer allocations or dereferences, this results in a transpilation error. This ensures most of the most common memory issues are not able to occur in safe particle environments, other than buffer overflows which we will mention later in this document.
