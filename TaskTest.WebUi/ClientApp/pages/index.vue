<template>
<div>
  aaaa
  <div class="header">
    <button v-if="isAuth()" @click="typeAuth=1">Login</button>
    <button v-if="isAuth()" @click="typeAuth=2">Register</button>
    <div class="use" v-if="!isAuth()">Authorized userr</div>
    <button v-if="!isAuth()" @click="logout()">Logout</button>
  </div>
  <div class="content">
    <div class="auth" v-if="typeAuth==1">
      Auth <br>
      <input type="text" v-model="email">
      <input type="password" v-model="password">
      
      <button @click="auth()">Login</button>
    </div>
    <div class="auth" v-if="typeAuth==2">
      Register <br>
      <input type="text" v-model="email" placeholder="email">
      <input type="password" v-model="password" placeholder="password">
      <input type="password" v-model="passwordConfirm" placeholder="confirm password">
      
      <button @click="reg()">Register</button>
    </div>
    <br>
    <div class="tests" v-if="openedTest==null">
      <button @click="getTests()">Get tetsts</button>
      <br>
      <div v-if="tests!=null">
        <div class="test" v-for="t in tests.data[0].test" v-bind:key="t.testId">
          <b>{{t.name}}</b><br>
          {{t.description}}<br>
          
          <input type="checkbox" id="agree" value="agree" v-model="agree">
          <label for="greea">I'm agree</label>
          <button v-if="!agree" disabled>start</button>
          <button v-else @click="openedTest = t.questions, page=0">start</button>
        </div>
      </div>
    </div>
    <div class="openedTest" v-else>
      <div class="questions">
        <div v-for="(q, index) in openedTest" v-bind:key="q.questionId">
          <div class="test" v-if="page==index">
          {{q.name}}<br>
            <div class="rad" v-for="a in q.answers" v-bind:key="a.quaestionId">
              <input type="radio" :id="a" :value="a" v-model="picked">
              <label :for="a">{{a.correct}} - {{a.answers}}</label>
            </div>
            <br>
            <button @click="calculate(), page++">Next</button>
          </div>
        </div>
          
          <div class="empty" v-if="page > Object.keys(openedTest).length-1">
            <h2>Result</h2>
            {{score}}<br>
            
            <button @click="openedTest = null, score = 0">Back</button>
          </div>
      </div>
      
    </div>
  </div>
</div>

</template>

<script>
export default {
  name: 'IndexPage',
  data() {
    return {
      typeAuth: -1,
      email: '',
      password: '',
      passwordConfirm: '',
      res: "",
      tests: null,
      openedTest: null,
      picked: null,
      page: null,
      score: 0,
      agree: false
    }
  },
  methods: {
    calculate(){
      if(this.picked.correct){
        this.score += 1
      }
    },
    isAuth(){
      return this.$cookies.get('.AspNetCore.Identity.Application') == null
    },
    auth(){
			this.$axios.post("https://localhost:44328/api/Authorization/login/", {
				Email: this.email,
				Password: this.password,
        RememberMe: true,
        returnUrl: 'sa'
        }).then(res => {
          this.res = this.$cookies.get('.AspNetCore.Identity.Application')
			})
    },
    reg(){
			this.$axios.post("https://localhost:44328/api/Authorization/", {
				Email: this.email,
				Password: this.password,
        PasswordConfirm: this.PasswordConfirm,
        }).then(res => {
          console.log('registered')
          this.start()
			})
    },
    logout(){
			this.$axios.post("https://localhost:44328/api/Authorization/logout", {
        }).then(res => {
          console.log('logout')
			})
    },
    start(){
			this.$axios.post("https://localhost:44328/api/test/start", {
        }).then(res => {
          console.log('start')
			})
    },
    getTests(){
			this.$axios.get("https://localhost:44328/api/test/getTest", {
        }).then(res => {
          this.tests = res
			})
    }
  }
}
</script>
<style scoped>
  .header{
    width: 100%;
    height: 50px;
    border-bottom: 2px solid grey;
  }
  .test{
    width: 100%;
    border-bottom: 1px solid grey;
  }
</style>