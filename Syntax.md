**Particle Language Syntax**
The conversions are written from the particle equivalent to the C/C++ equivalent, all language specific types will be categorised under another list in this document.

**Keywords For C/C++:**  <br>
in - int <br>
fl - float <br>
st - string <br>
ch - char <br>
vd - void <br>
cnst - const <br>
mut - mutable <br>

#inc<> - #include<> <br>
#def - #define <br>
name - namespace <br>
str - struct <br>
cls - class <br>
use - using <br>
rt - return <br>
dt - delete (becomes free() in C) <br>

**Code Examples**

**Printing Hello World**

#inc use <IO> <br>
use name std;

in main(vd) <br>
{ <br>
    ptf("Hello world"); <br>
    rt 0; <br>
}
