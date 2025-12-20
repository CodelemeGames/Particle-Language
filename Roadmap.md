# The Particle Language Roadmap

## **The Memory Consortium - Version 2.0.0**
This is particle's runtime memory manager. It will be what shall own all heap memory for a particle program, only allowing a specific handler type to be able to hold a reference to it; whilst allowing it to perform validity checks to prevent improper memory usage. 

This system will only perform checks when you access memory from it, which will only give you a T& as a result if you are using the C++ backend. This should allow the Memory Consortium to be relatively lightweight compared to a Garbage Collector; which would periodically check memory validity, which is different to our solution which will only check when needed.

However, we cannot predict it's performance relative to a Borrow Checker which you can see in Rust for example.

Currently, we are designing all the features for the Memory Consortium and we hope to begin work on it's implementation soon.

(Garbage Collector solutions are not bad either, they are effective at preventing memory issues, they are used in languages such as C# and Java. We do not want to make Garbage Collectors sound like bad solutions; we just use them as a point of reference).

## **Compiler Multithreading - Version 1.2.0**

The two main operations performed by the Particle compiler: parsing and safe code checks (checking for dereferences and raw pointers), will be moved to seperate C# tasks, each running asynchronously and will result in both results being returned to the main thread. 

This should allow for shorter compilation times as a particle code project increases in size.

We have been making changes to the code structure, mostly to bring a more functional programming approach to the main pipeline, to make the C# task handling code fit well into the codebase. We hope it will become fully functional soon.
