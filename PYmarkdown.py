import markdown # type: ignore
import os
if __name__ == '__main__':
    f = open('markdownDemo.txt', 'r')
    
    your_text_string = f.read()
    print(your_text_string)
    
    html = markdown.markdown(your_text_string)
    f.close()
    print(html)
