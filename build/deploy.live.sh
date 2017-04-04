echo "setup project variables"
echo "-----------------------"
export BRANCH="origin/release/live"
export COMMIT=${BITBUCKET_COMMIT}
export LOCATION="/web/app/Sexy/"
export SERVICE="sexy"

echo " "
echo "setup SSH client"
echo "----------------"
mkdir ~/.ssh

for I in 1;
do
    echo " "
    echo "build on server ${I}"
    echo "================="

    echo " "
    echo "setup server variables"
    echo "----------------------"
    SSHKEY=BB_LIV${I}_SSHKEY
    SSHUSER=BB_LIV${I}_SSHUSER
    SSHSERVER=BB_LIV${I}_SSHSERVER

    echo " "
    echo "setup SSH client (part 2)"
    echo "-------------------------"
    echo ${!SSHKEY} > ~/.ssh/id_rsa.tmp  # see: https://answers.atlassian.com/questions/39243415/how-can-i-use-ssh-in-bitbucket-pipelines
    base64 -d ~/.ssh/id_rsa.tmp > ~/.ssh/id_rsa
    chmod 600 ~/.ssh/id_rsa
    base64 ~/.ssh/id_rsa

    echo " "
    echo "login to server"
    echo "---------------"

ssh -o StrictHostKeyChecking=no ${!SSHUSER}@${!SSHSERVER} /bin/bash << EOF
    #!/bin/bash
    echo " "
    echo "set directory"
    echo "-------------"
    mkdir ${LOCATION}
    cd ${LOCATION}

    echo " "
    echo "fetch repository"
    echo "----------------"
    git -C ${LOCATION} fetch --all
    if [ -z ${COMMIT} ];
    then
        sudo git -C ${LOCATION} reset --hard ${BRANCH}
    else
        sudo git -C ${LOCATION} reset --hard ${COMMIT}
    fi

    echo " "
    echo "fix script permissions"
    echo "----------------------"
    sudo chmod -x ${LOCATION}build/build.application.sh

    echo " "
    echo "stop service"
    echo "---------------"
    sudo systemctl stop ${SERVICE}

    echo " "
    echo "build application"
    echo "-----------------"
    sudo bash ${LOCATION}build/build.application.sh

    echo " "
    echo "configure application"
    echo "---------------------"
    sudo cp ${LOCATION}build/conf.systemd.txt /etc/systemd/system/${SERVICE}.service

    echo " "
    echo "start service"
    echo "---------------"
    sudo systemctl daemon-reload
    sudo systemctl start ${SERVICE}
    sleep 10

    echo " "
    echo "================"
EOF
done

echo " "
echo "poke website"
echo "------------"
curl -v -I https://rly.sx
