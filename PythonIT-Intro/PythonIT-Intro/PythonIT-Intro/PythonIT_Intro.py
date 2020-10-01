
import time
import hashlib

#metoder
import random
import string

def sha256funktion(streng):
    h = hashlib.sha256()
    h.update(streng.encode('utf-8'))
    hex = h.hexdigest()
    return hex

def password_generator(length=10):
    printable = f'{letters}{numbers}'
    printable = list(printable)
    random.shuffle(printable)
    random_password = random.choices(printable, k=length)
    random_password = ''.join(random_password)
    return random_password

#opg 1
print("Hello World")

#opg 2
summen = sum(range(1,101))
print(summen)

#opg 4
secret = "815b0eeca9134e4445afe419300b419b033a306344e5cef549b1b671e9841237"

letters = string.ascii_letters
numbers = string.digits

placeholder = password_generator()
resultat = sha256funktion(placeholder)

i = 0

while resultat[:3] != secret[:3]:
    placeholder = password_generator()
    resultat = sha256funktion(placeholder)
    i+=1
    if resultat[:3] == secret[:3]:
        print("her er resultat " + resultat + " her er secret " + secret)
        

#opg5 og tid for 6

f = open("rockyou-1000.txt")
lines = f.readlines()
streng = ""
for line in lines:
    line = line.rstrip("\n\r")
    streng = sha256funktion(line)

hashvalue = "cff47fe5d92c58d654b08b2624bbb62aa5034530e3e5eff1f4a7186cba2e03fa"
start = time.process_time()
f = open("rockyou-1000.txt")
lines = f.readlines()
streng = ""
for line in lines:
    line = line.rstrip("\n\r")
    streng = sha256funktion(line)
    if hashvalue == streng:
        end = time.process_time()
        print("det rigtige password i opg5 er: " + line)
        print("hashværdien er " + streng)
        print(end - start, 'seconds')
        

#opg6
opg6tidstart = time.process_time()
sumopg6 = 0
print('opg 6 start')
for i in range(100000):
    #for j in range(1000):
        sumopg6 = sumopg6 + i #+ j
print("sum af opg6: ", sumopg6)
opg6tidend = time.process_time()
print("tid på opg6: ", opg6tidend - opg6tidstart, ' sekunder' )


#opg7
import bcrypt
pw = "Secret1234"
for loopopg7 in range(10):
    hashed = bcrypt.hashpw(pw.encode('utf-8'), bcrypt.gensalt(14))
    print('opg7 bcrypt', loopopg7, ': ',hashed.decode('utf-8'))


#opg8
opg8bcryptstring = "$2b$14$eAmP5DGJsS1ekQ2C5CfgxOEM9JVvWAm991MInc/CMeMh7M470Kdri"
opg8string = 'fernando'
opg8pw = bcrypt.hashpw(opg8string.encode('utf-8'),bcrypt.gensalt())
print(opg8pw, ' ||| ', opg8bcryptstring)
print(bcrypt.checkpw(opg8string.encode('utf-8'),opg8bcryptstring.encode('utf-8')))
#for line in lines:
    #print(line, ' is ', bcrypt.checkpw(line.encode('utf-8'),opg8bcryptstring.encode('utf-8')) )
    #if bcrypt.checkpw(line.encode('utf-8'),opg8bcryptstring.encode('utf-8')):
        #print('Det rigtige password i opg8 er: ', line)
        #print(line.encode('utf-8'), ' = ', opg8bcryptstring)

