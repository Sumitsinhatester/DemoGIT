

let server = require('supertest').agent('https://reqres.in');
let chai = require('chai'); // This is assertion library of nodejs
const { it } = require('node:test');


//This is describe() block to add a mocha test suite
describe('This is login Suite', function() {


    // This is it() block to add test case
    it('1. Verify when pass Valid Email and Password, it should login the user', function(done)
    {
        server
            .post('/api/login')     // This is method and route of request
            .set('accept', 'json')  // This is request header
            .send({                 // This is request body, payload
            "email": "eve.holt@reqres.in",
                "password": "cityslicka"
            })
            .end(function(err, res) { //This is callback function to handle the response
            if (err) throw err; // Throw error if error come
            else
            {
                console.log("this is token", res.body);
                // Assert api statusCode
                chai.expect(res.statusCode).to.equal(200);
                // Assert API response
                chai.expect(res.body).to.have.property('token');
                done()
                }

        })

    });

    it('2. Verify when pass Valid Email and not pass password, it should not login the user', function(done) {
        server
            .post('/api/login')
            .set('accept', 'json')
            .send({
            "email": "eve.holt@reqres.in"
            })
            .end(function(err, res) {
            if (err) throw err;
            else
            {
                console.log("this is token", res.body);
                chai.expect(res.body).to.have.property('error', 'Missing password');
                done()
                }

        })

    })

    it('3. Verify when pass Valid Email and invalid Password, it should throw error message', function(done) {
        server
            .post('/api/login')
            .set('accept', 'json')
            .send({
            "email": "eve.holt@reqres.in",
                "password": "9999999"
            })
            .end(function(err, res) {
            if (err) throw err;
            else
            {
                console.log("this is token", res.body);
                chai.expect(res.body).to.have.property('error', 'Your Password is invalid');
                done()
                }

        })

    });
    it('4. verify when pass invalid Email id and valid password, it should throw an error message', function(done){
        server
        .post('/api/login')
        .set('accept', 'json')
        .send({
            "email":"sumit.sin@reqres.in",
               "password":"6666666666"


        })
        .end(function(err, res){
            if (err) throw err;
            else
            {
                console.log("this is a token", res.body);
                chai.expect(res.body).to.have.property('error', 'Your Email id is invalid');
                done()
            }
        })
    })
    it('5. verify when pass invalid Email id and pass invalid password, it should throw an error message for invalid Email id and Invalid password', function(done){
        server
        .post('/api/login')
        .set('accept', 'json')
        .send({
            "email":"invalid@reqres.in",
               "password":"invalid"


            })
            .end(function(err, res){
            if (err) throw err;
            else
            {
                console.log("this is a token", res.body);
                chai.expect(res.body).to.have.property('error', 'Your Email is invalid and Your password is also invalid');
                done()
                }
        })
    })
    it('6. verify when pass valid Email id and pass valid password, it should throw a message about successful login and Go to the dashboard');
    server
    .post('/api/login')
    .set('accept', 'json')
    .send({
        "email":"valid@reqres.in",
                 "password":"valid"

        })   
        .end(function(err, res){
        if (err) throw err;
        else
        {
            console.log("This is a token", res.body);
            chai.expect(res.body).to.have.property('message', 'Your Email id is valid & Your passowrd is also valid');
            done()
                }
    })
});
