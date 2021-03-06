import rubberband
import soundfile

import array
from pydub import AudioSegment
from pydub.utils import get_array_type

sound = AudioSegment.from_file(file="file.mp3")
left = sound.split_to_mono()[0]

bit_depth = left.sample_width * 8
rate = bit_depth
array_type = get_array_type(bit_depth)

data = array.array(array_type, left._data)

# data,rate=soundfile.read('file.wav',dtype='int16')
# bitrate=rate*16
nFrames=len(data)
print(f'Raw input type is : {type(data)}')

oldDuration=nFrames/rate
newDuration=6
ratio=newDuration/oldDuration

out=rubberband.stretch(data,
rate=rate,
ratio=ratio,
crispness=5,
formants=False,
precise=True)
soundfile.write('outfile.wav',out,rate,'PCM_16')
