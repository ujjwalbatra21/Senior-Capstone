from flask import Flask
import pymysql

app = Flask(__name__)
conn = pymysql.connect(
    host= 'vcu-eras-application.cqdbzahrxvgz.us-east-1.rds.amazonaws.com',
    port= 3306,
    user= 'admin',
    password ='vcueras1!',
    db = 'VCU_ERAS',
)

@app.route('/')
def hello_world():
    return 'Hello World!'

@app.route('/surgeries', methods=['GET'])
def get_info():
    cur = conn.cursor()
    cur.execute("SELECT SurgeryInfo FROM Surgeries WHERE SurgeryName = 'Reconstructive Brest Surgery' ")
    details = cur.fetchall()
    print(details[0][0])
    return(details[0][0])

if __name__ == '__main__':
    app.run()
