pipeline {
     agent any
     environment {
        dockerImage = ''
        registry = 'ashish0786/jwtauthvalidation'
        registryCredential ='dockerhub_id'
    }
    stages {
        stage ('checkout') {
            steps {
                checkout([$class: 'GitSCM', branches: [[name: '*/main']], extensions: [], userRemoteConfigs: [[credentialsId: 'github_id', url: 'https://github.com/ashish0626/AuthPoc.git']]])
            }
        }
        stage('Build Docker Images') {
            steps {
                script {
                    dockerImage = docker.build registry
                }
            }
        }
        stage('Upload to DockerHub'){
            steps {
                script {
                        docker.withRegistry('',registryCredential){
                            dockerImage.push()
                        }
                }
            }
        }
        stage('docker stop container') {
         steps {
            sh 'docker ps -f name=exciting_newton  -q | xargs --no-run-if-empty docker container stop'
            sh 'docker container ls -a -fname=exciting_newton -q | xargs -r docker container rm'
         }
       }
       stage('Docker Run') {
        steps {
            script {
                dockerImage.run("-p 8020:80 --rm --name exciting_newton")
                }
            }
        }
    }
}
