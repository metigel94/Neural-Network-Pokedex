import time
import zmq
import os
import server
import threading

pokemon_images = ["python classify.py --model pokedex.model --labelbin lb.pickle --image examples/charmander_counter.png", "python classify.py --model pokedex.model --labelbin lb.pickle --image examples/bulbasaur_plush.png", "python classify.py --model pokedex.model --labelbin lb.pickle --image examples/pikachu_meme.png", "python classify.py --model pokedex.model --labelbin lb.pickle --image examples/pikachu_toy.png"]


def classify_pokemon(index):
    os.system(pokemon_images[int(index)])

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
            print(Connection.pokemon_number)

            if(message != Connection.pokemon_number):
                classify_pokemon(Connection.pokemon_number)

            Connection.pokemon_number = message.decode("utf-8")
            
            feedbackToUnity = Connection.pokemon_number

            #  In the real world usage, you just need to replace time.sleep() with
            #  whatever work you want python to do.-
            #time.sleep(1)

            #  Send reply back to client
            #  In the real world usage, after you finish your work, send your output here
            socket.send(feedbackToUnity)


Connection.server()