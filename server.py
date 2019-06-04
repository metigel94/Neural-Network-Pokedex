import time
import zmq
import os
import server
import threading
import subprocess


pokemon_images = ["python classify.py --model pokedex.model --labelbin lb.pickle --image examples/squirtle_unity.jpg", "python classify.py --model pokedex.model --labelbin lb.pickle --image examples/bulbasaur_unity.jpg", "python classify.py --model pokedex.model --labelbin lb.pickle --image examples/charmander_unity.jpg", "python classify.py --model pokedex.model --labelbin lb.pickle --image examples/mewto_unity.jpg", "python classify.py --model pokedex.model --labelbin lb.pickle --image examples/pikachu_meme.png"]


class Connection:
    pokemon_number = 0

    @staticmethod
    def server():
        context = zmq.Context()
        socket = context.socket(zmq.REP)
        socket.bind("tcp://*:5550")

        # messages = []

       
        while True:
            #  Wait for next request from client
            message = socket.recv()
            #print("Received request: %s" % message)

            if(message != Connection.pokemon_number):
                proc = subprocess.Popen(pokemon_images[int(message)], stdout=subprocess.PIPE, shell=True)
                (out, err) = proc.communicate()
                socket.send(out)

            Connection.pokemon_number = message.decode("utf-8")

            print(Connection.pokemon_number)
            
            #  In the real world usage, you just need to replace time.sleep() with
            #  whatever work you want python to do.-
            #time.sleep(1)

            #  Send reply back to client
            #  In the real world usage, after you finish your work, send your output here
            


Connection.server()