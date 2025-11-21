**Our Programming Philosophy**

The core of particle is it's inclusion of a different philosophy to writing code than in C or C++. It takes notes from Rust's approach for memory management and some standardised conventions to code structure.

We will also explain under each pillar nd rule why it was suitable and later chosen.

**1. Use only raw pointers when you have absolutely no alternative to the functionality you require.**

Raw pointers give lots of control to programmers, but they also pose some of the largest risks when writing software at a low-level. Security issues such as use-after-frees or dangling pointers are mostly caused by mishandling of these kinds of pointers. Therefore they should only be used in small-scale instances or highly monitored environments where the programmer knows exactly when a raw pointer is allocated and freed. 

Over time, languages such as C++ have been given newer solutions to heap allocated memory - such as smart pointers. However, since it is exclusive to the language, we highly recommend using stack memory which manages its own lifetime for as long as you possibly can if you are not targeting C++ - though remember that you should still try and track allocations in general as it keeps a firm grasp on the codebase.

In safe particle code environments (environments in which the transpiler has not been told to allow unsafe code), we have the transpiler look for any raw pointer allocations or dereferences, this results in a transpilation error. This ensures most of the most common memory issues are not able to occur in safe particle environments, other than buffer overflows which we will mention later in this document.

We do encourage you to look into your stack memory usage percentage, as it is significantly smaller than the space that can be used for heap allocations. As it would count as a reasonable exception to this rule, as continuation of stack memory may impact performance - though if you are going to use heap memory, make sure you know exactly when and where that memory is allocated, used or freed.

**Refrain from passing data or whole objects around the codebase, use references instead.**

Passing pointers into functions as parameters can lead to nullptr dereferences, this is undefined behavour and will typically result in a crash. However, this is not the only issue, calling free on a pointer does not always mean that memory is immediately written as 0x0, in some operating systems the memory block is marked to be written to later - this can lead to Use-After-Free vulnerbilities, which can lead to Arbitrary Code Execution. Though if the memory was never allocated by your program in the first place, it will usually result in undefined behavour because of a null dereference and will then crash, as stated prior.

We recommend references to data instead, it guarantees that no null issues arise; which leads to less crashes from undefined behavour and less security vulnerbilities as a result of a data lifetime misconception. <br>

**Keep your names simple, to the point, and quick to understand to your future self.** <br>

Every programmer at some point in their codebases have written variable names that only make sense to them at that current moment. This approach leads to names that will become nonsense in a week or so; you begin to think more like your peers the more you drift away from the original thought process, this happens to everyone, maybe not a day or two, but usually it begins to become this way around the one week mark. <br>

We recommend short names, not so short that they will become nonsense themselves, but short enough to type quickly, and to think quickly, if you have a variables named 'health' then keep it as 'health'; though if you have something on the lines of 'MouseSensitivity', that can be easy to say to yourself in your mind; but not quick to write - the goal is to find some middle ground, we highly recommend asking yourself this question: 'Is this name as fast to write as it is to think?' It may not be the largest change but you will almost certainly see a development time decrease in the long run; and hopefully less time to ease into your code base after a long period of time.
