;Maciej Rzeünik, grupa 4, sekcja 2
;Informatyka SSI 2022/23
;Temat projektu: Dodawanie efektu echa do pliku düwiÍkowego o rozszerzeniu WAVE

; Define the parameters (okomentowac)
.data
;constDly1     dq      4410; = 0.1 * 44100, kolejne dlugosci opoznienia echa
;constDly2     dq      13230; = 0.3 * 44100
;constDly3     dq      22050; = 0.5 * 44100
constG1      dq      0.5 ;stale odpowiadajace za glosnosc koeljnych probek echa 
constG2      dq      0.1
constG3      dq      0.05

.code
;Procedura dodajπca efekt echa
;paramtery wej:
;rcx -> numSamples (ilosc probek)
;rdx -> output (wskaünik do pliku wyjsciowego)
;r8 -> waveData (wskaünik do pliku wejúciowego)

;parametry wyj:
;brak

MyEchoProc proc

mov r15, 0 ;i, which is later used to calculate echo for each sample
lea r12, [r8] ;load address of the first sample to r12
; Loop over the samples
echoLoop:
        
; Load the current sample
movsx rax, word ptr [r8] ;load first sample to rax
add r8, 2 ;move pointer to the next sample

; Check if the sample has echoes
mov r14, r15 ;move i to r14
sub r14, 22050;constDly3
cmp r14, 0 ;if r14 - 22050 is less then zero it means that there is no echo effect
jl store ;and the samples should be stored without any changes, otherwise load echo

; Load the echoes 

mov r9, 4410 ;constDly1, move constantDly1 to r9
mov r10, r15 ;mov i to r10
sub r10, r9 ;perform i - constDly1
imul r10, 2 ;then multiply it by 2
lea r13, [r12] ;load address of first sample to r13
add r13, r10 ;add r10 to the address of first sample to get proper echo sample
movsx rbx, word ptr [r13] ;move the sample to  rbx

cvtsi2sd xmm0, rbx ;convert int stored in rbx  to double and move it to xmm0
movsd xmm1, constG1 ;move constG1 to xmm1
mulpd xmm0, xmm1 ;perform xmm0(proper echo sample) * xmm1(const gain1)
CVTSD2SI rbx, xmm0 ;convert double stored in xmm0 to int and move it to rbx

add rax, rbx ;now add the echo sample to the current sample
;now the code repeats 2 more times for another echo values

mov r9, 13230; constDly2
mov r10, r15
sub r10, r9
imul r10, 2
lea r13, [r12]
add r13, r10
movsx rbx, word ptr [r13]

cvtsi2sd xmm0, rbx
movsd xmm1, constG2
mulpd xmm0, xmm1
CVTSD2SI rbx, xmm0

add rax, rbx

mov r9, 22050; constDly3
mov r10, r15
sub r10, r9
imul r10, 2
lea r13, [r12]
add r13, r10
movsx rbx, word ptr [r13]

cvtsi2sd xmm0, rbx
movsd xmm1, constG3
mulpd xmm0, xmm1
CVTSD2SI rbx, xmm0

add rax, rbx
;Here adding echo effect ends

; Store the modified sample in the output array
store:
mov word ptr [rdx], ax ;move changed sample to output array
add rdx, 2 ;change pointer to the next sample

; Decrement the sample counter and continue the loop
inc r15 ;increment i
dec rcx ;decrement number of echo samples
jnz echoLoop    ;if there any samples left, continue adding echos
                ;otherwise end the procedure

; Return from the procedure
ret
MyEchoProc endp
end