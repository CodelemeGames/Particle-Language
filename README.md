# Particle-Language
A memory-aware hyperset programming language which transpiled down to safe C and C++ code. Essentually, shorter keyword names and a new design philosopy - influenced by great languages such as Rust; but with no runtime checks from our side - thats a guarantee.

**Why Particle?**  <br>
Languages such as Rust, C# and Python are known for their memory safe nature - either by leveraging a garbage collector or borrow checker. This is great for ensuring no memory issues arise at runtime; though with one caveat, performance. Rust is designed with speed in mind, and it achieves code performance out of the box which is something to be impressed by - though it still needs to have runtime checks to ensure that your program runs as flawless as possible - which leaves it's true potential of C-like performance and safety on the table. Thats where Particle comes in, to allow for code to be written that leverages the speed of mature compilers with languages known for their blazingly fast code - though with little memory safeguards; leaving the floodgates open for a wide variety of CVEs and crashes.

As previously stated, particle has shorter keyword names than the likes of C++, Javascript or Java - this was chosen to keep a familiar syntax to the languages it transpiles to; as we hope to make it quick to convert your particle code to C or C++ in your head as quick as possible (and to some extent to convert your particle code with the transpiler).

Though I must say, all referenced languages as comparison to particle are all amazing, we highly recommend looking at what all of them can produce - when they have strengths, they are great using them. We aren't trying to make an opinion for you on the best language - that is extremely subjective.
