# MightyXOR (aka. Amgine)
<p align="center">
<img src="Images/logo.png" alt="Amgine's Logo"/>
</p>

MightyXOR / Amgine [ˈɛmd͡ʒɪn] is an open source cryptography software suite based on .NET 6 with the primary aim of being information-theoretically secure, meaning its encrypted files cannot be decrypted even if an adversary has unlimited computing resources and time.

It supports various en- and decryption algorithms and techniques, including
- a one-time pad (OTP) mode,
- Shamir secret sharing (SSS) and
- plausible deniability.

## Context

Given the increasing usage of highly efficient quantum computers, the question arises, when – not if – these will be able to break widely used cryptography algorithms like AES or RSA in a short space of time.
Thus, Amgine's purpose is to provide a secure environment for especially sensitive data by means of information-theoretically secure techniques. One of these techniques is the one-time pad.
It [was mathematically proven](http://math.umd.edu/~lcw/OneTimePad.pdf) that the one-time pad **cannot be broken** – even with vast computational power.

## Goals
To put it in a (tiny) nutshell, we – as Amgine developers – are pursuing the following goals:

- Security on all levels
    - Reliable, correctly implemented algorithms such as the OTP
    - Cryptographically secure, (hardware-)generated true randomness
    - Key distribution using Shamir's secret sharing scheme
    - Plausible deniability
- Free, open source software
- Understandable, maintainable, readable source code

In the future, we intend to extend Amgine to support more techniques:

- Further information-theoretically secure cryptosystems
- A more efficient sharing scheme, namely the (k, n)-threshold secret sharing scheme described [in this paper](https://www.researchgate.net/publication/220905280_A_New_k_n-Threshold_Secret_Sharing_Scheme_and_Its_Extension)
- An API for hardware random number generators (HRNGs)
- Cross-plattform support for Linux and macOS concerning Amgine's graphical user interface

## Usage

Amgine provides a graphical user interface which currently only runs on Windows operating systems.

### CLI (command line interface)

A cross-plattform CLI is being worked on.

### GUI (graphical user interface)

The GUI is based on Windows Forms and will be replaced by a WPF-based application as soon as possible. As depicted in this screenshot, it is divided into several components:

<img src="Images/main_menu.png" alt="Amgine's GUI"/>

<hr>

The encryption menu allows both ordinary OTP-based encryption and an extended one-time pad with plausible deniability. In both cases, Amgine offers advanced options to customize the encryption process to your choice.

In the decryption menu, an encrypted file can be decrypted using a key. If plausible deniability was used previously, Amgine behaves exactly as if it was not used. This way, an attacker would not recognize that an alternative key was involved.

Amgine also supports a secret sharing mode according to Adi Shamir's scheme based on polynomial interpolation. Using this mode, a given file can be split into *N* parts whereas *K* parts are required to restore the entire file.

It is recommended to combine Amgine's features in order to maximize the security. For instance, it may be feasible to encrypt a sensitive file with a OTP including plausible deniability and split both the encrypted file and keys afterwards. Under the correct circumstances, it is impossible to break this cryptosystem.
## FAQ
### What does the name mean?

Reading *Amgine* backwards gives the answer to this question. However, Amgine is supposed to be much easier to use than Enigma.

### Should I use Amgine instead of Veracrypt or BitLocker to encrypt my sensitive data?

No. At the moment, Amgine does not claim to offer the features a software such as VeraCrypt does. Comparing Amgine to other cryptography software is difficult since Amgine can be seen as a niche product. Furthermore, Amgine encrypts on the file level, whereas VeraCrypt and BitLocker encrypt on the volume level. Consider Amgine a useful extension to your cryptography toolset which you can use to en- and decrypt your especially sensitive data.
### How can I contribute to the Amgine project?

Any contribution to the Amgine project, be it documentation, testing or development is warmly welcome. As an Amgine developer, however, it should be your top priority to develop a secure, clean and easy-to-use software product. Security is crucial. Please refer to [this guide](CONTRIBUTING.md) for (new) Amgine contributors for more detailled information.

### I am thinking of a new feature for Amgine. How can I share it?

Ideas for new features can be posted in the [issues section](../../issues). Please orientate yourself by the following aspects when proposing a new feature:

- Summary
- Motivation
- Detailed design
- *optional:* Drawbacks
- *optional:* Alternatives

## License

The license is declared [in this file](LICENSE).
